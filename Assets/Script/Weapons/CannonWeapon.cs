using Script.Bullets;
using Script.Factories;
using Script.Players;
using Script.Postions;
using UnityEngine;

namespace Script.Weapons
{
    public class CannonWeapon : BaseWeapon
    {
        private readonly WeaponParameter _parameter;
        private readonly RegistablesFactory<CannonBullet> _factory;

        public CannonWeapon(RegistablesFactory<CannonBullet> factory, Const.Attribute attribute)
        {
            _factory = factory;
            _parameter = new WeaponParameter(attribute);
        }

        public override void Execute(Point current, Point forward)
        {
            var bullet = _factory.Create(current);
            bullet.Parameter = _parameter;
            bullet.AttackForward = forward;
            if(forward.X > 0) bullet.transform.rotation = Quaternion.Euler(0, 90, 0);
            if(forward.X < 0) bullet.transform.rotation = Quaternion.Euler(0, -90, 0);
            if(forward.Y > 0) bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
            if(forward.Y < 0) bullet.transform.rotation = Quaternion.Euler(0, 180, 0);
            //bullet.transform.LookAt(Camera.main.transform);
            bullet.Execute();
        }
    }
}
