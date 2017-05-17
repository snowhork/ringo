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

        protected RegistablesFactory(GameObject registable, DiContainer container)
        {
            _registable = registable;
            _container = container;
        }

        public T Create(Point point)
        {
            var registable =  _container.InstantiatePrefabForComponent<T>(_registable);
            registable.Point = point;
            registable.RegisterOnMapTip();
            return registable;
        }
    }

    public class RegistablesFactory<TBase, T> : RegistablesFactory<TBase>
        where  T : TBase
        where TBase : Object, IRegistable
    {
        public RegistablesFactory(GameObject registable, DiContainer container) : base(registable, container)
        {
        }
    }
}
