using System.Collections.Generic;
using Script.Characters;
using Script.Signals;
using Script.UI;
using Script.Weapons;

namespace Script.Players
{
    public class PlayerParameter : BaseCharacterParameter
    {
        public PlayerParameter(IWeapon currentWeapon, ISpecialWeapon specialWeapon,
            Const.Attribute attribute, HpParameter parameter)
            : base(currentWeapon, specialWeapon, attribute, parameter)
        {
        }
    }
}

