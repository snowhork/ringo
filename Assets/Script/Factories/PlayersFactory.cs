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

        public PlayersFactory(GameObject player, DiContainer container)
        {
            _player = player;
            _container = container;
        }

        public PlayerFacade Create(Point point)
        {
            var player = _container.InstantiatePrefabForComponent<PlayerFacade>(_player);
            player.Point = point;
            player.SetTransform();
            return player;
        }
    }
}
