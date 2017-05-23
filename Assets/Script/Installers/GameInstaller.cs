using Script.Attackers;
using Script.Bullets;
using Script.Characters;
using Script.Damages;
using Script.Factories;
using Script.Items;
using Script.Maps;
using Script.Players;
using Script.Weapons;
using UnityEngine;
using Zenject;

namespace Script.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _normalMapTip;
        [SerializeField] private GameObject[] _portions;
        [SerializeField] private GameObject[] _blocks;
        [SerializeField] private GameObject _bombBullet;

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

            Container.Bind<IItemGetter>().To<PlayerItemGetter>().AsTransient();
            Container.Bind<IBehaviour>().To<PlayerBehaviour>().AsTransient();
            Container.Bind<BaseCharacterParameter>().To<PlayerParameter>().AsTransient();
            Container.Bind<IAttacker>().To<PlayerAttacker>().AsTransient();
            Container.Bind<IMover>().To<PlayerMover>().AsTransient();
            Container.Bind<IDamagable>().To<PlayerDamager>().AsTransient();
            Container.Bind<IPlayer>().FromComponentInNewPrefab(_player).AsSingle().NonLazy();

            Container.Bind<ITickable>().To<MainLoop>().AsSingle();

            Container.Bind<Camera>().FromComponentInHierarchy();
        }
    }
}
