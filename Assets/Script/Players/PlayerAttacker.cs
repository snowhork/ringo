using Script.Creatures;
using Script.Attackers;

namespace Script.Players
{
    public class PlayerAttacker : IAttacker
    {
        public PlayerAttacker(PlayerParameter parameter)
        {
            _parameter = parameter;
        }

        private PlayerParameter _parameter;

        public void Execute(ICreature creature)
        {
           creature.Damage(this);
        }
    }
}
