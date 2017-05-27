using Script.Attackers;
using Script.Bullets;
using Script.Characters;
using Script.Effect;
using Script.Factories;
using Script.Hits;
using Script.Items;
using Script.Maps;
using Script.Players;
using Script.Postions;
using Script.UI;
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
        [SerializeField] private GameObject[] _items;
        [SerializeField] private GameObject[] _players;
        [SerializeField] private GameObject _effectsUi;

        public override void InstallBindings()
        {            
            Container.Bind<MapTipsFactory>()
                .To<MapTipsFactory>().AsSingle()
                .WithArguments(_normalMapTip,  new GameObject("MapTips").transform);
            Container.Bind<IMapTipsCore>().To<MapTipsCore>().AsSingle();
            Container.Bind<IMapCreator>().To<MapCreator>().AsSingle();
            Container.Bind<IItemSpawner>().To<ItemSpawner>().AsSingle();
            Container.Bind<IMapTipsCollection>().To<MapTipsCollection>().AsSingle().NonLazy();

            foreach (var block in _blocks)
            {
                Container.Bind<BlocksFactory>()
                    .AsTransient()
                    .WithArguments(block, new GameObject("Blocks").transform);
            }

            Container.Bind<ITickable>().To<MainLoop>().AsSingle();

            foreach (var item in _items)
            {
                Container.Bind<ItemsFactory>()
                    .AsTransient()
                    .WithArguments(item, new GameObject("Items").transform);
            }

            var playerParent = new GameObject("Players");
            foreach (var player in _players)
            {
                Container.Bind<PlayersFactory>().AsTransient().WithArguments(player, playerParent.transform);
                //Container.BindIFactory<Point, PlayersFactory, PlayerFacade>().FromSubContainerResolve().ByNewPrefab<PlayerInstaller>(player);
            }

            Container.Bind<EffectUi>().FromComponentInNewPrefab(_effectsUi).AsSingle().NonLazy();
        }
    }
}
