using Script.Maps;
using UnityEngine;
using Zenject;

namespace Script.Factories
{
    public class MapTipsFactory : IFactory<BaseMapTip>
    {
        private readonly GameObject _mapTip;
        private readonly DiContainer _container;

        protected MapTipsFactory(GameObject mapTip, DiContainer container)
        {
            _mapTip = mapTip;
            _container = container;
        }

        public BaseMapTip Create()
        {
            return  _container.InstantiatePrefabForComponent<BaseMapTip>(_mapTip);
        }
    }
}
