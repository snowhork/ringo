using Script.Attributes;
using Script.Bullets;
using Script.Factories;
using Script.Players;
using Script.Postions;

namespace Script.Weapons
{
    public abstract class BaseSpecialWeapon : ISpecialWeapon, IAttribute
    {
        private readonly WeaponParameter _parameter = new WeaponParameter(Const.Attribute.Fire);

        public abstract void Execute(Point current, Point forward);

        public WeaponParameter Parameter
        {
            get { return _parameter; }
        }

        public Const.Attribute Attribute
        {
            get { return _parameter.Attribute; }
        }
    }
}
