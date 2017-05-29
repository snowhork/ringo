using System;
using System.Collections.Generic;
using Script.Postions;
using Script.Signals;
using Script.Weapons;
using UniRx;
using UnityEngine;

namespace Script.Characters
{
    [Serializable]
    public class BaseCharacterParameter
    {
        [SerializeField] private float _speed;
        private Point _point;

        private readonly HpParameter _hpParameter;

        public IObservable<int> OnHpChanged
        {
            get { return _hpParameter.OnHpChanged; }
        }

        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        private Const.Attribute _attribute;
        
        public Const.Attribute Attribute
        {
            get { return _attribute; }
        }

        private readonly List<IWeapon> _weapons;
        private IWeapon _currentWeapon;

        public BaseCharacterParameter(List<IWeapon> weapons, Const.Attribute attribute, HpParameter hpParameter)
        {
            _weapons = weapons;
            _attribute = attribute;
            _hpParameter = hpParameter;
            _currentWeapon = _weapons[0];
        }

        public int Hp
        {
            get { return _hpParameter.Hp; }
            set { _hpParameter.Hp = value; }
        }

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public IWeapon CurrentWeapon
        {
            get { return _currentWeapon; }
        }

        public IObservable<Unit> OnDied
        {
            get { return _hpParameter.OnDied; }
        }
    }
}
