using System.Collections.Generic;
using Script.Factories;
using Script.Postions;
using UnityEngine;

namespace Script.Items
{
    public class ItemSpawner : IItemSpawner
    {
        private readonly List<RegistablesFactory<BaseItem>> _factories;

        public ItemSpawner(List<RegistablesFactory<BaseItem>> factories)
        {
            _factories = factories;

            // for Debug

        }

        public void Spawn()
        {
            Point[] points0 =
            {
                new Point(1, 1), new Point(2, 2), new Point(3, 3)
            };
            foreach (var point in points0)
            {
                var item = _factories[0].Create(point);
                item.SetTransforn();
            }

            Point[] points1 =
            {
                new Point(5, 1), new Point(6, 2), new Point(8, 4)
            };
            foreach (var point in points1)
            {
                var item = _factories[1].Create(point);
                item.SetTransforn();
            }
        }
    }
}
