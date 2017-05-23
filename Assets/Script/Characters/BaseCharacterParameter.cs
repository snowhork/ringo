﻿using System;
using System.Collections.Generic;
using Script.Weapons;
using UnityEngine;

namespace Script.Characters
{
    [Serializable]
    public class BaseCharacterParameter
    {
        [SerializeField] private int _hp;
        [SerializeField] private int _maxHp;
        [SerializeField] private int _attack;
        [SerializeField] private float _speed;

        private readonly List<IWeapon> _weapons;
        private IWeapon _currentWeapon;

        public BaseCharacterParameter(List<IWeapon> weapons)
        {
            _weapons = weapons;
            _currentWeapon = _weapons[0];
        }

        public int Hp
        {
            get { return _hp; }
            set
            {
                _hp = value;
            }
        }

        public int MaxHp
        {
            get { return _maxHp; }
            set { _maxHp = value; }
        }

        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
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
