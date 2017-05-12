using Script.Attackers;

namespace Script.Damages
{
    public interface IDamagable
    {
        void Damage(IAttacker attacker);
    }
}

