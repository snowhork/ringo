using System.Collections.Generic;
using Script.Characters;
using Script.Weapons;

namespace Script.Players
{
    public class PlayerParameter : BaseCharacterParameter
    {
        public PlayerParameter(List<IWeapon> weapons) : base(weapons)
        {
        }
    }
}
