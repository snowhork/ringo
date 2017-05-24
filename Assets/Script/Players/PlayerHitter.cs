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

        public bool Hit(IAttacker attacker)
        {
            if (_parameter.Attribute == attacker.Attribute) return false;
            return true;
        }
    }
}
