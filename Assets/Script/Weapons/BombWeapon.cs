using Script.Bullets;
using Script.Factories;
using Script.Players;
using Script.Postions;

namespace Script.Weapons
{
    public class BombWeapon : BaseWeapon
    {
        private readonly WeaponParameter _parameter = new WeaponParameter(Const.Attribute.Fire);
        private readonly RegistablesFactory<BombBullet> _factory;

        public BombWeapon(RegistablesFactory<BombBullet> factory)
        {
            _factory = factory;
        }

        public override void Execute(Point current, Point forward)
        {
            var bullet = _factory.Create(current);
            bullet.Parameter = _parameter;
            bullet.AttackForward = forward;
            bullet.Execute();
        }
    }
}
