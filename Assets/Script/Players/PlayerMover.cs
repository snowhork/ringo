using Script.Maps;
using Script.Postions;
using UnityEngine;

namespace Script.Players
{
    public class PlayerMover
    {
        private readonly MapTipsBehaviour _mapTips;
        private readonly IPlayer _player;

        public PlayerMover(MapTipsBehaviour mapTips, IPlayer player)
        {
            _mapTips = mapTips;
            _player = player;
        }

        public void Execute(Point point)
        {
            var currentMapTip = _mapTips.GetMapTip(_player.Point);

            currentMapTip.Remove(_player);
            _player.Point += point;
            var nextMapTip = _mapTips.GetMapTip(_player.Point);
            nextMapTip.Register(_player);
        }
    }
}
