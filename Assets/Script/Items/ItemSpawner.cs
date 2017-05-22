using System.Collections.Generic;
using Script.Factories;
using Script.Maps;
using Script.Postions;
using UnityEngine;

namespace Script.Items
{
    public class ItemSpawner : IItemSpawner
    {
        private readonly IMapTipsCollection _collection;
        private readonly List<RegistablesFactory<BaseItem>> _factories;

        public ItemSpawner(IMapTipsCollection collection, List<RegistablesFactory<BaseItem>> factories)
        {
            _collection = collection;
            _factories = factories;
        }

        public void Spawn()
        {
            var index = Random.Range(0, 2);
            var point = new Point(Random.Range(_collection.ColStartIndex, _collection.ColEndIndex), Random.Range(0, 6));
            if(_collection.GetMapTip(point.X, point.Y).Item != null) return;
            var item = _factories[index].Create(point);
            item.SetTransforn();
        }
    }
}
