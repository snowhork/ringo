using System;
using Script.Attackers;
using UnityEngine;

namespace Script.Weapons
{
    [Serializable]
    public class WeaponParameter : IAttacker
    {
        [SerializeField] private int _power;
        [SerializeField] private int _range;
        [SerializeField] private int _speed;
        private Const.Attribute _attribute;

        public WeaponParameter(Const.Attribute attribute)
        {
            _attribute = attribute;
        }

        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }

        public int Range
        {
            get { return _range; }
            set { _range = value; }
        }

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Const.Attribute Attribute
        {
            get { return _attribute; }
        }
    }
}
