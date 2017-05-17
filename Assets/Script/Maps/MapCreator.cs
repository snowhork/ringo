using System.Collections.Generic;
using Script.Factories;
using UnityEngine;

namespace Script.Maps
{
    public class MapCreator : IMapCreator
    {
        private readonly IMapTipsCollection _collection;
        private readonly List<MapTipsFactory> _factories;

        public MapCreator(IMapTipsCollection collection, List<MapTipsFactory> factories)
        {
            _collection = collection;
            _factories = factories;

            for (var j = 0; j < 12; j++)
            {
                CreateCol();
            }
        }

        public void CreateCol()
        {
            var tips = new[]
            {
                _factories[0].Create(),
                _factories[0].Create(),
                _factories[0].Create(),
                _factories[0].Create(),
                _factories[0].Create(),
                _factories[0].Create(),
            };
            _collection.AppendCol(tips);
        }

        public void RemoveCol()
        {
            _collection.RemoveCol();
        }
    }
}
