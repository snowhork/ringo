using Script.Attackers;
using Script.Characters;
using Script.Damages;
using Script.Factories;
using Script.Items;
using Script.Maps;
using Script.Players;
using UnityEngine;
using Zenject;

namespace Script.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _normalMapTip;
        [SerializeField] private GameObject[] _portions;

        public override void InstallBindings()
        {
            Container.Bind<MapTipsFactory>()
                .To<MapTipsFactory>().AsSingle()
                .WithArguments(_normalMapTip);
            Container.Bind<IMapTipsCore>().To<MapTipsCore>().AsSingle();

            foreach (var portion in _portions)
            {
                Container.Bind<RegistablesFactory<BaseItem>>()
                    .To<RegistablesFactory<BaseItem>>()
                    .AsTransient()
                    .WithArguments(portion);
            }
            Container.Bind<IItemSpawner>().To<ItemSpawner>().AsSingle().NonLazy();

            Container.Bind<IItemGetter>().To<PlayerItemGetter>().AsTransient();
            Container.Bind<IMoveInput>().To<PlayerMoveInput>().AsTransient();
            Container.Bind<IBehaviour>().To<PlayerBehaviour>().AsTransient();
            Container.Bind<BaseCharacterParameter>().To<PlayerParameter>().AsTransient();
            Container.Bind<IAttacker>().To<PlayerAttacker>().AsTransient();
            Container.Bind<IMover>().To<PlayerMover>().AsTransient();
            Container.Bind<IDamagable>().To<PlayerDamager>().AsTransient();
            Container.Bind<IPlayer>().FromComponentInNewPrefab(_player).AsSingle().NonLazy();
        }
    }
}
