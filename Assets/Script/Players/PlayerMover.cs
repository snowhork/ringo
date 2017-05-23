using Script.Characters;
using Script.Postions;
using UnityEngine;

namespace Script.Players
{
    public class PlayerMover : IMover
    {
        private readonly IPlayer _player;

        private PlayerMover(IPlayer player)
        {
            _player = player;
        }

        public void Execute(Point point)
        {
            _player.RemoveFromMapTip();
            _player.Point += point;
            _player.RegisterOnMapTip();
        }
    }
}
