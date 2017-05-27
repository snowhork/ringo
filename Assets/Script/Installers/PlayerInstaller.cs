﻿using Script.Attackers;
using Script.Bullets;
using Script.Characters;
using Script.Effect;
using Script.Factories;
using Script.Hits;
using Script.Players;
using Script.UI;
using Script.Weapons;
using UnityEngine;
using Zenject;
using UnityEngine;


namespace Script.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _bombBullet;
        [SerializeField] private Const.Attribute _attribute;
        [SerializeField] private GameObject _effect;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private HeartUi _heartUi;

        public override void InstallBindings()
        {
            var id = (int) _attribute;
            Container.BindInstance(id);
            Container.BindInstance(_attribute);
            Container.BindInstance(_renderer);
            Container.Bind<HeartUi>().FromComponentInNewPrefab(_heartUi).AsCached().NonLazy();
            Container.Bind<IBehaviour>().To<PlayerBehaviour>().AsTransient().WithArguments(_transform);
            Container.Bind<BaseCharacterParameter>().To<PlayerParameter>().AsCached();
            Container.Bind<IHittable>().To<PlayerHitter>().AsCached();
            Container.Bind<IPlayerInput>().To<PlayerInputByKey>().AsCached();
            //Container.Bind<IPlayerInput>().To<PlayerInputByJoyCon>().AsCached();


            Container.Bind<IWeapon>()
                .To<CannonWeapon>()
                .AsTransient()
                .WithArguments(_attribute);

            Container.Bind<RegistablesFactory<CannonBullet>>()
                .AsTransient()
                .WithArguments(_bombBullet, new GameObject("Bullets").transform);

            Container.Bind<RegistablesFactory<BaseEffect>>()
                .AsTransient()
                .WithArguments(_effect, new GameObject("Effects").transform);
        }
    }
}
