﻿using Script.Attackers;
using Script.Bullets;
using Script.Characters;
using Script.Effect;
using Script.Factories;
using Script.Hits;
using Script.Items;
using Script.Maps;
using Script.Players;
using Script.Postions;
using Script.Weapons;
using UniRx;
using UnityEngine;
using Zenject;

namespace Script.Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _normalMapTip;
        [SerializeField] private GameObject[] _blocks;
        [SerializeField] private GameObject[] _players;

        public override void InstallBindings()
        {
            Container.Bind<MapTipsFactory>()
                .To<MapTipsFactory>().AsSingle()
                .WithArguments(_normalMapTip,  new GameObject("MapTips").transform);
            Container.Bind<IMapTipsCore>().To<MapTipsCore>().AsSingle();
            Container.Bind<IMapCreator>().To<MapCreator>().AsSingle();
            Container.Bind<IMapTipsCollection>().To<MapTipsCollection>().AsSingle().NonLazy();

            foreach (var block in _blocks)
            {
                Container.Bind<BlocksFactory>()
                    .AsTransient()
                    .WithArguments(block, new GameObject("Blocks").transform);
            }

            Container.Bind<ITickable>().To<MainLoop>().AsSingle();

            var playerParent = new GameObject("Players");
            foreach (var player in _players)
            {
                Container.Bind<PlayersFactory>().AsTransient().WithArguments(player, playerParent.transform);
                //Container.BindIFactory<Point, PlayersFactory, PlayerFacade>().FromSubContainerResolve().ByNewPrefab<PlayerInstaller>(player);
            }
        }
    }
}
