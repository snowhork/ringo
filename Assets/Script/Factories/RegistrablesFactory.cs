using Script.Maps;
using Script.Postions;
using UnityEngine;
using Zenject;

namespace Script.Factories
{
    public class RegistablesFactory<T> : IFactory<Point, T> where T : Object, IRegistable
    {
        private readonly GameObject _registable;
        private readonly IMapTipsCore _mapTipsCore;
        private readonly DiContainer _container;
        private readonly Transform _parent;

        protected RegistablesFactory(GameObject registable, DiContainer container, Transform parent)
        {
            _registable = registable;
            _container = container;
            _parent = parent;
        }

        public T Create(Point point)
        {
            var registable =  _container.InstantiatePrefabForComponent<T>(_registable, _parent);
            registable.Point = point;
            registable.RegisterOnMapTip();
            return registable;
        }
    }
}
