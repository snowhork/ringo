using System.Collections;
using Script.Attackers;
using Script.Characters;
using Script.Maps;
using Script.Postions;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Script.Players
{
    public class PlayerBehaviour : IBehaviour
    {
        private readonly BaseCharacterParameter _parameter;
        private readonly IPlayer _player;
        private readonly IMapTipsCore _mapTipsCore;

        private readonly PlayerMoveInput _moveInput = new PlayerMoveInput();
        private readonly PlayerAttackInput _attackInput = new PlayerAttackInput();
        private readonly IMover _mover;

        private bool _isMoving = false;
        private bool _isAttacking = false;

        public PlayerBehaviour(
            BaseCharacterParameter parameter,
            IPlayer player,
            IMapTipsCore mapTipsCore,
            IMover mover)
        {
            _parameter = parameter;
            _player = player;
            _mapTipsCore = mapTipsCore;
            _mover = mover;
        }

        public void Execute()
        {
            var moveForward = _moveInput.MoveInput();
            var attackForward = _attackInput.AttackInput();

            if (!(moveForward   == Point.Zero() || _isMoving)) Moving(moveForward);
            if (!(attackForward == Point.Zero() || _isAttacking )) Attacking(attackForward);
        }

        private void Moving(Point moveForward)
        {
            SetRotation(moveForward);

            var nextPoint = _player.Point + moveForward;
            if (!_mapTipsCore.EnterableMapTip(nextPoint)) return;

            var player = _mapTipsCore.GetPlayer(nextPoint);
            var block = _mapTipsCore.GetBlock(nextPoint);

            if (player != null) return;
            if (block != null) return;

            _player.ExecuteCoroutine(MoveCoroutine(moveForward));
        }

        private void Attacking(Point attackForward)
        {
            SetRotation(attackForward);
            _parameter.CurrentWeapon.Execute(attackForward);
            _isAttacking = true;
            _player.ExecuteCoroutine(Charge());
        }

        private void SetRotation(Point forward)
        {
            if(forward.X > 0) _player.Transform.rotation = Quaternion.Euler(0, 90, 0);
            if(forward.X < 0) _player.Transform.rotation = Quaternion.Euler(0, -90, 0);
            if(forward.Y > 0) _player.Transform.rotation = Quaternion.Euler(0, 0, 0);
            if(forward.Y < 0) _player.Transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        private IEnumerator Charge()
        {
            yield return new WaitForSeconds(1f);
            _isAttacking = false;
        }

        private IEnumerator MoveCoroutine(Point inputMove)
        {
            _isMoving = true;
            var speed = 0.1f;
            var startPos = _player.Transform.position;
            var delta = 0f;

            for(; delta <= BaseMapTip.TipSize/2; delta += speed)
            {
                _player.Transform.position +=
                    new Vector3(inputMove.X, 0, inputMove.Y) * speed;
                yield return null;
            }
            _mover.Execute(inputMove);
            for(; delta <= BaseMapTip.TipSize; delta += speed)
            {
                _player.Transform.position +=
                    new Vector3(inputMove.X, 0, inputMove.Y) * speed;
                yield return null;
            }

            _player.Transform.position = startPos + new Vector3(inputMove.X, 0, inputMove.Y) * BaseMapTip.TipSize;
            _isMoving = false;
        }
    }
}
