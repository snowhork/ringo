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
        private IWeapon _currentWeapon;
        private ISpecialWeapon _specialWeapon;
        private int _specialWeaponCount;

        public BaseCharacterParameter(IWeapon currentWeapon, ISpecialWeapon specialWeapon, Const.Attribute attribute, HpParameter hpParameter)
        {
            _attribute = attribute;
            _currentWeapon = currentWeapon;
            _specialWeapon = specialWeapon;
            _hpParameter = hpParameter;

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

        public IWeapon SpecialWeapon
        {
            get { return _specialWeapon; }
        }

        public int SpecialWeaponCount
        {
            get { return _specialWeaponCount; }
            set { _specialWeaponCount = value; }
        }
        public IObservable<Unit> OnDied
        {
            get { return _hpParameter.OnDied; }
        }
    }
}
