using Script.Attackers;
using Script.Characters;
using Script.Maps;
using Script.Postions;
using UnityEngine;
using Zenject;

namespace Script.Players
{
    public class PlayerBehaviour : IBehaviour
    {
        private readonly BaseCharacterParameter _parameter;
        private readonly IPlayer _player;
        private readonly IMapTipsCore _mapTipsCore;

        private readonly IItemGetter _getter;
        private readonly IAttacker _attacker;
        private readonly IMoveInput _moveInput;
        private readonly IMover _mover;

        public PlayerBehaviour(
            BaseCharacterParameter parameter,
            IPlayer player,
            IMapTipsCore mapTipsCore,
            IItemGetter getter,
            IAttacker attacker,
            IMoveInput moveInput,
            IMover mover)
        {
            _parameter = parameter;
            _player = player;
            _mapTipsCore = mapTipsCore;
            _getter = getter;
            _attacker = attacker;
            _moveInput = moveInput;
            _mover = mover;
        }

        public void Execute()
        {
            var inputMove = _moveInput.MoveInput();
            if (inputMove == Point.Zero()) return;

            var nextPoint = _player.Point + inputMove;
            if(!_mapTipsCore.EnterableMapTip(nextPoint)) return;

            var player   = _mapTipsCore.GetPlayer(nextPoint);
            var creature = _mapTipsCore.GetCreature(nextPoint);
            var item     = _mapTipsCore.GetItem(nextPoint);

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
