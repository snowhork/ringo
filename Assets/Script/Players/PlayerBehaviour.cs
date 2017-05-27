using System.Collections;
using System.Runtime.Remoting.Metadata;
using Script.Attackers;
using Script.Characters;
using Script.Hits;
using Script.Maps;
using Script.Postions;
using UniRx;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Script.Players
{
    public class PlayerBehaviour : IBehaviour
    {
        private readonly BaseCharacterParameter _parameter;
        private readonly Transform _transform;
        private readonly IMapTipsCore _mapTipsCore;
        private readonly IHittable _hitter;

        private readonly PlayerMoveInput _moveInput = new PlayerMoveInput();
        private readonly PlayerAttackInput _attackInput = new PlayerAttackInput();

        private bool _isMoving = false;
        private bool _isAttacking = false;

        private readonly Subject<Unit> _removeSubject = new Subject<Unit>();
        private readonly Subject<Unit> _registerSubject = new Subject<Unit>();

        public PlayerBehaviour(
            BaseCharacterParameter parameter,
            Transform transform,
            IMapTipsCore mapTipsCore,
            IHittable hitter)
        {
            _parameter = parameter;
            _transform = transform;
            _mapTipsCore = mapTipsCore;
            _hitter = hitter;
        }

        public void Execute()
        {
            var moveForward = _moveInput.MoveInput();
            var attackForward = _attackInput.AttackInput();

            if (!(moveForward   == Point.Zero() || _isMoving)) Moving(moveForward);
            if (!(attackForward == Point.Zero() || _isAttacking )) Attacking(attackForward);
        }

        public IObservable<Unit> RemoveFromMapTip
        {
            get { return _removeSubject; }
        }

        public IObservable<Unit> RegisterOnMapTip
        {
            get { return _registerSubject; }
        }

        private void Moving(Point moveForward)
        {
            SetRotation(moveForward);

            var nextPoint = _parameter.Point + moveForward;
            if (!_mapTipsCore.EnterableMapTip(nextPoint)) return;

            var player = _mapTipsCore.GetPlayer(nextPoint);
            var block = _mapTipsCore.GetBlock(nextPoint);
            var item = _mapTipsCore.GetItem(nextPoint);
            var effect = _mapTipsCore.GetEffect(nextPoint);
            HitInfo info;

            if (player != null) return;
            if (block != null) return;
            if (item != null) item.Use(_parameter);
            if (effect != null) _hitter.Hit(effect, out info);

            Observable.FromCoroutine(_ => MoveCoroutine(moveForward)).Subscribe();
        }

        private void Attacking(Point attackForward)
        {
            SetRotation(attackForward);
            _parameter.CurrentWeapon.Execute(_parameter.Point, attackForward);
            _isAttacking = true;
            Observable.FromCoroutine(Charge).Subscribe();
        }

        private void SetRotation(Point forward)
        {
            if(forward.X > 0) _transform.rotation = Quaternion.Euler(0, 90, 0);
            if(forward.X < 0) _transform.rotation = Quaternion.Euler(0, -90, 0);
            if(forward.Y > 0) _transform.rotation = Quaternion.Euler(0, 0, 0);
            if(forward.Y < 0) _transform.rotation = Quaternion.Euler(0, 180, 0);
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
            var startPos = _transform.position;
            var delta = 0f;

            for(; delta <= BaseMapTip.TipSize/2; delta += speed)
            {
                _transform.position +=
                    new Vector3(inputMove.X, 0, inputMove.Y) * speed;
                yield return null;
            }
            ChangeRegister(inputMove);
            for(; delta <= BaseMapTip.TipSize; delta += speed)
            {
                _transform.position +=
                    new Vector3(inputMove.X, 0, inputMove.Y) * speed;
                yield return null;
            }

            _transform.position = startPos + new Vector3(inputMove.X, 0, inputMove.Y) * BaseMapTip.TipSize;
            _isMoving = false;
        }

        private void ChangeRegister(Point point)
        {
            _removeSubject.OnNext(Unit.Default);
            _parameter.Point += point;
            _registerSubject.OnNext(Unit.Default);
        }
    }
}
