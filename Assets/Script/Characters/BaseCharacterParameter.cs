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
        private float _speed = 0.1f;
        private float _coolTime = 1.0f;
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
        private ReactiveProperty<int> _specialWeaponCount = new ReactiveProperty<int>(0);

        public IObservable<int> OnSpecialWeaponCount
        {
            get { return _specialWeaponCount; }
        }

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

        public float CoolTime
        {
            get { return _coolTime; }
            set { _coolTime = value; }
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
            get { return _specialWeaponCount.Value; }
            set { _specialWeaponCount.Value = value; }
        }
        public IObservable<Unit> OnDied
        {
            get { return _hpParameter.OnDied; }
        }
    }
}
