using Script.Characters;
using Script.Postions;

namespace Script.Players
{
    public class PlayerParameter : BaseCharacterParameter
    {
        public PlayerParameter(int hp=100, int maxHp=100, int attack=10, float speed=1.0f) : base(hp, maxHp, attack, speed)
        {
        }
    }
}
