using Script.Maps;
using Script.Postions;
using UnityEngine;
using Zenject;

namespace Script.Factories
{
    public class MapTipsFactory : IFactory<Point, BaseMapTip>
    {
        private readonly GameObject _mapTip;
        private readonly DiContainer _container;
        private readonly Transform _parent;

        protected MapTipsFactory(GameObject mapTip, DiContainer container, Transform parent)
        {
            _mapTip = mapTip;
            _container = container;
            _parent = parent;
        }

        public BaseMapTip Create(Point point)
        {
            var tip = _container.InstantiatePrefabForComponent<BaseMapTip>(_mapTip, _parent);
            tip.Point = point;
            tip.SetTransform();
            return tip;
        }
    }
}
