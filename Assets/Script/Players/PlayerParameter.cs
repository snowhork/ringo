using System.Collections.Generic;
using Script.Characters;
using Script.UI;
using Script.Weapons;

namespace Script.Players
{
    public class PlayerParameter : BaseCharacterParameter
    {
        public PlayerParameter(IWeapon currentWeapon, IWeapon specialWeapon, Const.Attribute attribute)
            : base(currentWeapon, specialWeapon, attribute)
        {
        }
    }
}
