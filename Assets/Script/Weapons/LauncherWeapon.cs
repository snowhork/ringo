using Script.Bullets;
using Script.Factories;
using Script.Players;
using Script.Postions;

namespace Script.Weapons
{
    public class LauncherWeapon : BaseWeapon
    {
        private readonly WeaponParameter _parameter = new WeaponParameter(Const.Attribute.Fire);
        private readonly RegistablesFactory<LauncherBullet> _factory;

        public LauncherWeapon(RegistablesFactory<LauncherBullet> factory)
        {
            _factory = factory;
        }

        public override void Execute(Point current, Point attackForward)
        {
            var bullet = _factory.Create(current);
            bullet.Parameter = _parameter;
            bullet.AttackForward = attackForward;
            bullet.Execute();
        }
    }
}
