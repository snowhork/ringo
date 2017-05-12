using Script.Maps;
using Script.Postions;
using UnityEngine;

namespace Script.Players
{
    public class PlayerBehaviour
    {
        private readonly PlayerInput _input = new PlayerInput();
        private readonly PlayerItemGetter _getter;
        private readonly PlayerAttacker _attacker;
        private readonly PlayerMover _mover;
        private readonly IPlayer _player;
        private readonly MapTipsBehaviour _mapTips;

        public PlayerBehaviour(IPlayer player, MapTipsBehaviour mapTips, PlayerParameter parameter)
        {
            _player = player;
            _mapTips = mapTips;
            _mover = new PlayerMover(_mapTips, _player);
            _attacker = new PlayerAttacker(parameter);
            _getter = new PlayerItemGetter(parameter);
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

                _player.Transform.position += new Vector3(inputMove.X * MapTipsBehaviour.TipSize, 0,
                    inputMove.Y * MapTipsBehaviour.TipSize);

            }
        }
    }
}
