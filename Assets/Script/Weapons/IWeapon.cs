using Script.Postions;

namespace Script.Weapons
{
    public interface IWeapon
    {
        void Execute(Point current, Point forward);
        WeaponParameter Parameter { get; }
    }
}
