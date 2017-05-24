using Script.Attackers;

namespace Script.Hits
{
    public interface IHittable
    {
        bool Hit(IAttacker attacker);
    }
}
