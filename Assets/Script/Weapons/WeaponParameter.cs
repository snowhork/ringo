using System;
using UnityEngine;

namespace Script.Weapons
{
    [Serializable]
    public class WeaponParameter
    {
        [SerializeField] private int _power;
        [SerializeField] private int _range;
        [SerializeField] private int _speed;
    }
}
