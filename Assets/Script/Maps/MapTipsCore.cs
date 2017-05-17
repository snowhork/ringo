using System.Collections.Generic;
using Script.Creatures;
using Script.Factories;
using Script.Items;
using Script.Players;
using Script.Postions;

namespace Script.Maps
{
    public class MapTipsCore : IMapTipsCore
    {
        public const float TipSize = 1f;
        private readonly MapTipsCollection _mapTipsCollection;

        private MapTipsCore(List<MapTipsFactory> factories)
        {
            _mapTipsCollection = new MapTipsCollection(factories);
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
