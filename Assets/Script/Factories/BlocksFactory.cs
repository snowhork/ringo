using Script.Blocks;
using Script.Maps;
using Script.Postions;
using UnityEngine;
using Zenject;

namespace Script.Factories
{
    public class BlocksFactory : IFactory<Point, BaseBlock>
    {
        private readonly GameObject _block;
        private readonly DiContainer _container;
        private readonly Transform _parent;

        public BlocksFactory(GameObject block, DiContainer container, Transform parent)
        {
            _block = block;
            _container = container;
            _parent = parent;
        }

        public BaseBlock Create(Point point)
        {
            var block = _container.InstantiatePrefabForComponent<BaseBlock>(_block, _parent);
            block.Point = point;
            block.SetTransform();
            return block;
        }
    }
}
