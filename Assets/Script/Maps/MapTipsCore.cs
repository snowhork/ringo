using Script.Blocks;
using Script.Bullets;
using Script.Effect;
using Script.Items;
using Script.Players;
using Script.Postions;
using UnityEngine;

namespace Script.Maps
{
    public class MapTipsCore : IMapTipsCore
    {
        public const float TipSize = 1f;
        private readonly IMapTipsCollection _mapTipsCollection;

        private MapTipsCore(IMapTipsCollection mapTipsCollection)
        {
            _mapTipsCollection = mapTipsCollection;
        }

        private BaseMapTip GetMapTip(Point point)
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

        public IBlock GetBlock(Point point)
        {
            return GetMapTip(point).Block;
        }

        public void Register(IItem registrable)
        {
            GetMapTip(registrable.Point).Register(registrable);
        }

        public void Register(IBlock registrable)
        {
            GetMapTip(registrable.Point).Register(registrable);
        }

        public void Register(IPlayer registrable)
        {
            GetMapTip(registrable.Point).Register(registrable);
        }

        public void Register(IBullet registrable)
        {
            GetMapTip(registrable.Point).Register(registrable);
        }

        public void Register(IEffect registrable)
        {
            GetMapTip(registrable.Point).Register(registrable);
        }

        public void Remove(IItem registrable)
        {
            GetMapTip(registrable.Point).Remove(registrable);
        }

        public void Remove(IBlock registrable)
        {
            GetMapTip(registrable.Point).Remove(registrable);
        }

        public void Remove(IPlayer registrable)
        {
            GetMapTip(registrable.Point).Remove(registrable);
        }

        public void Remove(IBullet registrable)
        {
            GetMapTip(registrable.Point).Remove(registrable);
        }

        public void Remove(IEffect registrable)
        {
            GetMapTip(registrable.Point).Remove(registrable);
        }
    }
}
