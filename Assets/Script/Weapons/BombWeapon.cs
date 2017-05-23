using Script.Bullets;
using Script.Factories;
using Script.Players;
using Script.Postions;
using UnityEngine;

namespace Script.Weapons
{
    public class BombWeapon : IWeapon
    {
        private readonly IPlayer _player;
        private readonly WeaponParameter _parameter = new WeaponParameter();
        private readonly RegistablesFactory<BombBullet> _factory;

        public BombWeapon(IPlayer player, RegistablesFactory<BombBullet> factory)
        {
            _player = player;
            _factory = factory;
        }

        public void Execute(Point attackForward)
        {
            var bullet = _factory.Create(_player.Point);
            bullet.Parameter = _parameter;
            bullet.AttackForward = attackForward;
            bullet.Execute();
        }

        public WeaponParameter Parameter
        {
            get { return _parameter; }
        }
    }
}
