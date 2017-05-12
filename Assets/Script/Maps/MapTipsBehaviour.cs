using Script.Creatures;
using Script.Items;
using Script.Players;
using Script.Postions;
using UnityEngine;

namespace Script.Maps
{
    public class MapTipsBehaviour : MonoBehaviour
    {
        public const float TipSize = 1f;
        private MapTipsCollection _mapTipsCollection;

        private void Awake()
        {
            _mapTipsCollection = new MapTipsCollection();
        }

        public BaseMapTip GetMapTip(int x, int y)
        {
            return _mapTipsCollection.GetMapTip(x, y);
        }

        public BaseMapTip GetMapTip(Point point)
        {
            return _mapTipsCollection.GetMapTip(point.X, point.Y);
        }

        public bool EnterableMapTip(Point point)
        {
            return _mapTipsCollection.Enterable(point.X, point.Y);
        }

        public IItem GetItem(Point point)
        {
            return GetMapTip(point).Item;
        }

        public IPlayer GetPlayer(Point point)
        {
            return GetMapTip(point).Player;
        }

        public ICreature GetCreature(Point point)
        {
            return GetMapTip(point).Creature;
        }
    }
}
