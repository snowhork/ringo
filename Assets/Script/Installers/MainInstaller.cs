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
using Script.Weapons;
using UniRx;
using UnityEngine;
using Zenject;

namespace Script.Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _normalMapTip;
        [SerializeField] private GameObject[] _portions;
        [SerializeField] private GameObject[] _blocks;
        [SerializeField] private GameObject[] _effects;
        [SerializeField] private GameObject _bombBullet;
        [SerializeField] private GameObject _player;

        public override void InstallBindings()
        {
            Container.Bind<MapTipsFactory>()
                .To<MapTipsFactory>().AsSingle()
                .WithArguments(_normalMapTip);
            Container.Bind<IMapTipsCore>().To<MapTipsCore>().AsSingle();
            Container.Bind<IMapCreator>().To<MapCreator>().AsSingle();
            Container.Bind<IMapTipsCollection>().To<MapTipsCollection>().AsSingle().NonLazy();

            foreach (var portion in _portions)
            {
                Container.Bind<RegistablesFactory<BaseItem>>()
                    .To<RegistablesFactory<BaseItem>>()
                    .AsTransient()
                    .WithArguments(portion);
            }

            foreach (var block in _blocks)
            {
                Container.Bind<BlocksFactory>()
                    .AsTransient()
                    .WithArguments(block);
            }

            Container.Bind<RegistablesFactory<BombBullet>>()
                .To<RegistablesFactory<BombBullet>>()
                .AsSingle()
                .WithArguments(_bombBullet);

            Container.Bind<IWeapon>()
                .To<BombWeapon>()
                .AsTransient();

            foreach (var effect in _effects)
            {
                Container.Bind<RegistablesFactory<BaseEffect>>()
                    .AsTransient()
                    .WithArguments(effect);
            }

            Container.Bind<ITickable>().To<MainLoop>().AsSingle();

            Container.Bind<PlayersFactory>().AsSingle().WithArguments(_player);
            Container.BindIFactory<Point, PlayersFactory, PlayerFacade>().FromSubContainerResolve().ByNewPrefab<PlayerInstaller>(_player);
        }
    }
}
