using UnityEngine;
using Script.Attackers;
using Script.Characters;
using Script.Hits;

namespace Script.Players
{
    public class PlayerHitter : IHittable
    {
        private BaseCharacterParameter _parameter;

        public PlayerHitter(BaseCharacterParameter parameter)
        {
            _parameter = parameter;
        }

        public bool Hit(IAttacker attacker, out HitInfo info)
        {
            if (_parameter.Attribute == attacker.Attribute)
            {
                info = new HitInfo(this, attacker, false);
                return false;
            }
            _parameter.Hp--;
            Debug.Log(_parameter.Hp);
            info = new HitInfo(this, attacker, true);
            return true;
        }
    }
}
