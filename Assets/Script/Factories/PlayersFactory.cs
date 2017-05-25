using System.CodeDom;
using Script.Blocks;
using Script.Players;
using Script.Postions;
using UnityEngine;
using Zenject;

namespace Script.Factories
{
    public class PlayersFactory : IFactory<Point, PlayerFacade>
    {
        private readonly GameObject _player;
        private readonly DiContainer _container;
        private readonly Transform _parent;

        public PlayersFactory(GameObject player, DiContainer container, Transform parent)
        {
            _player = player;
            _container = container;
            _parent = parent;
        }

        public PlayerFacade Create(Point point)
        {
            var player = _container.InstantiatePrefabForComponent<PlayerFacade>(_player, _parent);
            player.Point = point;
            player.SetTransform();
            player.RegisterOnMapTip();
            return player;
        }
    }
}
