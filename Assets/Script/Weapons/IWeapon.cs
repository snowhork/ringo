using Script.Postions;

namespace Script.Weapons
{
    public interface IWeapon
    {
        void Execute(Point attackForward);
        WeaponParameter Parameter { get; }
    }
}
