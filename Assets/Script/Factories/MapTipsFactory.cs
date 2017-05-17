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

        protected MapTipsFactory(GameObject mapTip, DiContainer container)
        {
            _mapTip = mapTip;
            _container = container;
        }

        public BaseMapTip Create(Point point)
        {
            var positionbale =  _container.InstantiatePrefabForComponent<BaseMapTip>(_mapTip);
            positionbale.Point = point;
            return positionbale;
        }
    }
}
