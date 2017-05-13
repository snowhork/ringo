using Script.Maps;
using Script.Postions;
using UnityEngine;
using Zenject;

namespace Script.Players
{
    [RequireComponent(typeof(PlayerParameter), typeof(PlayerMover), typeof(IPlayer))]
    public class PlayerBehaviour : MonoBehaviour
    {
        private PlayerItemGetter _getter;
        private PlayerAttacker _attacker;
        private PlayerInput _input;

        private PlayerParameter _parameter;
        private PlayerMover _mover;
        private IPlayer _player;
        [Inject] private MapTipsCore _mapTips;

        private void Start()
        {
            _mover = GetComponent<PlayerMover>();
            _player = GetComponent<IPlayer>();
            _parameter = GetComponent<PlayerParameter>();

            _attacker = new PlayerAttacker(_parameter);
            _getter = new PlayerItemGetter(_parameter);
            _input = new PlayerInput();
        }

        public void Execute()
        {
            var inputMove = _input.MoveInput();

            if (inputMove != Point.Zero())
            {
                var nextPoint = _player.Point + inputMove;
                if(!_mapTips.EnterableMapTip(nextPoint)) return;

                var player   = _mapTips.GetPlayer(nextPoint);
                var creature = _mapTips.GetCreature(nextPoint);
                var item     = _mapTips.GetItem(nextPoint);

                if (player != null) return;
                if (creature != null)
                {
                    _attacker.Execute(creature);
                    return;
                }
                if (item != null)
                {
                    _getter.Execute(item);
                }
                _mover.Execute(inputMove);

                _player.Transform.position += new Vector3(inputMove.X * MapTipsCore.TipSize, 0,
                    inputMove.Y * MapTipsCore.TipSize);

            }
        }
    }
}
