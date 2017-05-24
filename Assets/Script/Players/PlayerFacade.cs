using System;
using System.Collections;
using Script.Attackers;
using Script.Characters;
using Script.Hits;
using Script.Maps;
using Script.Postions;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Script.Players
{
    public class PlayerFacade : MonoBehaviour, IPlayer
    {
        private IMapTipsCore _mapTipsCore;

        private BaseCharacterParameter _parameter;
        private IBehaviour _behaviour;
        private IHittable _hittable;

        public Point Point
        {
            get { return _parameter.Point; }
            set { _parameter.Point = value; }
        }

        public GameObject GameObject
        {
            get { return gameObject; }
        }

        [Inject]
        public void Construct(IMapTipsCore mapTipsCore, BaseCharacterParameter parameter, IBehaviour behaviour,
            IHittable hittable)
        {
            _parameter = parameter;
            _behaviour = behaviour;
            _hittable = hittable;
            _mapTipsCore = mapTipsCore;

            _behaviour.RegisterOnMapTip.Subscribe(_ => RegisterOnMapTip());
            _behaviour.RemoveFromMapTip.Subscribe(_ => RemoveFromMapTip());
        }

        public Transform Transform
        {
            get { return transform; }
        }

        public void ExecuteCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }

        public bool Hit(IAttacker attacker)
        {
            return _hittable.Hit(attacker);
        }

        public void SetTransform()
        {
            transform.position = new Vector3(BaseMapTip.TipSize*Point.X, 1f, BaseMapTip.TipSize*Point.Y);
        }

        private void Update()
        {
            _behaviour.Execute();
        }

        public void RegisterOnMapTip()
        {
            _mapTipsCore.Register(this);
        }

        public void RemoveFromMapTip()
        {
            _mapTipsCore.Remove(this);
        }

        public Const.Attribute Attribute
        {
            get { return _parameter.Attribute; }
        }

    }
}
