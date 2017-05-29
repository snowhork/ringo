using Script.Bullets;
using Script.Factories;
using Script.Players;
using Script.Postions;
using UnityEngine;

namespace Script.Weapons
{
    public class SpecialWeapon : BaseSpecialWeapon
    {
        private readonly WeaponParameter _parameter;
        private readonly RegistablesFactory<SpecialBullet> _factory;

        public SpecialWeapon(RegistablesFactory<SpecialBullet> factory, Const.Attribute attribute)
        {
            _factory = factory;
            _parameter = new WeaponParameter(attribute);
        }

        public override void Execute(Point current, Point forward)
        {
            Debug.Log("おチンチン");
            var bullet = _factory.Create(current);
            bullet.Parameter = _parameter;
            bullet.AttackForward = forward;
            bullet.Execute();
        }
    }
}
