using System;
using System.Collections.Generic;
using Script.Postions;
using Script.UI;
using Script.Weapons;
using UniRx;
using UnityEngine;

namespace Script.Characters
{
    [Serializable]
    public class BaseCharacterParameter
    {
        private IntReactiveProperty _hp = new IntReactiveProperty(3);
        [SerializeField] private float _speed;
        private Point _point;

        public IObservable<int> OnHpChanged
        {
            get { return _hp; }
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

        public BaseCharacterParameter(List<IWeapon> weapons, Const.Attribute attribute)
        {
            _weapons = weapons;
            _attribute = attribute;
            _currentWeapon = _weapons[0];
        }

        public int Hp
        {
            get { return _hp.Value; }
            set
            {
                _hp.Value = value;
            }
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
    }
}
