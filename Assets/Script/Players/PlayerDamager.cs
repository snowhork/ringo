using Script.Attackers;
using Script.Characters;
using Script.Damages;
using UnityEngine;

namespace Script.Players
{
    public class PlayerDamager : IDamagable
    {
        private BaseCharacterParameter _parameter;

        public PlayerDamager(BaseCharacterParameter parameter)
        {
            _parameter = parameter;
        }

        public void Execute(IAttacker attacker)
        {

        }

        public void Damage(IAttacker attacker)
        {

        }
    }
}
