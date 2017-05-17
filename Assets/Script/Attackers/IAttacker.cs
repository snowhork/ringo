using Script.Damages;

namespace Script.Attackers
{
    public interface IAttacker
    {
        void Execute(IDamagable damagable);
    }
}
