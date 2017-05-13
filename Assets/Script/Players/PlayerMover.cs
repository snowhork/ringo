using Script.Maps;
using Script.Postions;
using UnityEngine;
using Zenject;

namespace Script.Players
{
    public class PlayerMover : MonoBehaviour
    {
        [Inject] private MapTipsCore _mapTips;
        private IPlayer _player;

        private void Start()
        {
            _player = GetComponent<IPlayer>();
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
