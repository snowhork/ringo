using System;
using System.Collections.Generic;
using Script.Postions;
using Script.UI;
using Script.Weapons;
using UnityEngine;

namespace Script.Characters
{
    [Serializable]
    public class BaseCharacterParameter
    {
        private int _hp = 3;
        [SerializeField] private float _speed;
        private Point _point;

        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        private Const.Attribute _attribute;
        private readonly HeartUi _heartUi;

        public Const.Attribute Attribute
        {
            get { return _attribute; }
        }

        private readonly List<IWeapon> _weapons;
        private IWeapon _currentWeapon;

        public BaseCharacterParameter(List<IWeapon> weapons, Const.Attribute attribute, HeartUi heartUi)
        {
            _weapons = weapons;
            _attribute = attribute;
            _heartUi = heartUi;
            _currentWeapon = _weapons[0];
        }

        public int Hp
        {
            get { return _hp; }
            set
            {
                _hp = value;
                _heartUi.SetHeart(_hp);
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
