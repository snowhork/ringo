using Script.Items;
using Script.Maps;
using Script.Postions;
using UnityEngine;
using Zenject;

namespace Script.Factories
{
    public class ItemsFactory : IFactory<Point, BaseItem>
    {
        private readonly GameObject _item;
        private readonly DiContainer _container;
        private readonly Transform _parent;

        public ItemsFactory(GameObject item, DiContainer container, Transform parent)
        {
            _item = item;
            _container = container;
            _parent = parent;
        }

        public BaseItem Create(Point point)
        {
            var item = _container.InstantiatePrefabForComponent<BaseItem>(_item, _parent);
            item.Point = point;
            item.SetTransform();
            return item;
        }
    }
}
