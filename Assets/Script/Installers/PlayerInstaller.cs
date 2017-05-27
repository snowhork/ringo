﻿using Script.Attackers;
using Script.Bullets;
using Script.Characters;
using Script.Effect;
using Script.Factories;
using Script.Hits;
using Script.Players;
using Script.Weapons;
using UnityEngine;
using Zenject;
using UnityEngine;


namespace Script.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _cannonBullet;
        [SerializeField] private Const.Attribute _attribute;
        [SerializeField] private GameObject _effect;

        public override void InstallBindings()
        {
            Container.BindInstance(_attribute);
            Container.Bind<IBehaviour>().To<PlayerBehaviour>().AsTransient().WithArguments(_transform);
            Container.Bind<BaseCharacterParameter>().To<PlayerParameter>().AsCached();
            Container.Bind<IHittable>().To<PlayerHitter>().AsCached();

            Container.Bind<IWeapon>()
                .To<CannonWeapon>()
                .AsTransient()
                .WithArguments(_attribute);

            Container.Bind<RegistablesFactory<CannonBullet>>()
                .AsTransient()
                .WithArguments(_cannonBullet, new GameObject("Bullets").transform);

            Container.Bind<RegistablesFactory<BaseEffect>>()
                .AsTransient()
                .WithArguments(_effect, new GameObject("Effects").transform);
        }
    }
}
