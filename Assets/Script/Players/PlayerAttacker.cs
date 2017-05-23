using Script.Attackers;
using Script.Characters;
using Script.Damages;

namespace Script.Players
{
    public class PlayerAttacker : IAttacker
    {
        public PlayerAttacker(BaseCharacterParameter parameter)
        {
            _parameter = parameter;
        }

        private BaseCharacterParameter _parameter;

        public void Execute(IDamagable damagable)
        {
           damagable.Damage(this);
        }
    }
}
