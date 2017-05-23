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

        public BlocksFactory(GameObject block, DiContainer container)
        {
            _block = block;
            _container = container;
        }

        public BaseBlock Create(Point point)
        {
            var block = _container.InstantiatePrefabForComponent<BaseBlock>(_block);
            block.Point = point;
            block.SetTransform();
            return block;
        }
    }
}
