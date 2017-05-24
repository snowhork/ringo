
using Script.Attackers;
using Script.Characters;
using Script.Factories;
using Script.Hits;
using Script.Players;
using UnityEngine;
using Zenject;
using UnityEngine;


namespace Script.Installers
{
    public class PlayerInstaller : MonoInstaller<PlayerInstaller>
    {
        [SerializeField] private Transform _transform;

        public override void InstallBindings()
        {
            Container.Bind<IItemGetter>().To<PlayerItemGetter>().AsTransient();
            Container.Bind<IBehaviour>().To<PlayerBehaviour>().AsTransient().WithArguments(_transform);
            Container.Bind<BaseCharacterParameter>().To<PlayerParameter>().AsTransient();
            Container.Bind<IAttacker>().To<PlayerAttacker>().AsTransient();
            Container.Bind<IHittable>().To<PlayerHitter>().AsTransient();
        }
    }
}
