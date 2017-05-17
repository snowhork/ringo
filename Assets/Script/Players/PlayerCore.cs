using System;
using Script.Attackers;
using Script.Characters;
using Script.Damages;
using Script.Maps;
using Script.Postions;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Script.Players
{
    public class PlayerCore : MonoBehaviour, IPlayer
    {
        private IMapTipsCore _mapTipsCore;

        [SerializeField]
        private BaseCharacterParameter _parameter;
        private IBehaviour _behaviour;
        private IDamagable _damagable;

        private Point _point;

        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        [Inject]
        public void Construct(IMapTipsCore mapTipsCore, BaseCharacterParameter parameter, IBehaviour behaviour, IDamagable damagable)
        {
            _parameter = parameter;
            _behaviour = behaviour;
            _damagable = damagable;
            _mapTipsCore = mapTipsCore;
        }

        private void Start()
        {
            this.UpdateAsObservable().Take(1)
                .Subscribe(_ =>
                {
                    _point = new Point(0,0);
                    _mapTipsCore.Register(this);
                    SetTransform();
                });
        }

        public Transform Transform
        {
            get { return transform; }
        }

        public void Damage(IAttacker attacker)
        {
            _damagable.Damage(attacker);
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
    }
}
