using System.Collections.Generic;
using Script.Factories;
using Script.Installers;
using Script.Postions;
using UnityEngine;
using Zenject;

namespace Script.Maps
{
    public class ItemSpawner : IItemSpawner
    {
        private readonly DiContainer _container;
        private readonly IMapTipsCollection _collection;
        private readonly List<ItemsFactory> _itemsFactories;

        public ItemSpawner(DiContainer container, IMapTipsCollection collection,
            List<ItemsFactory> itemsFactories)
        {
            _container = container;
            _collection = collection;
            _itemsFactories = itemsFactories;
        }

        public void Spawn(Point point)
        {
			var x = point.X;
			var y = point.Y;
			var tip = _collection.GetMapTip(x, y);
			tip.Register(_itemsFactories[1].Create(point));
        }
    }
}
