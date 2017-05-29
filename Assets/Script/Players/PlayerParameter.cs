using System.Collections.Generic;
using Script.Characters;
using Script.Signals;
using Script.UI;
using Script.Weapons;

namespace Script.Players
{
    public class PlayerParameter : BaseCharacterParameter
    {
        public PlayerParameter(List<IWeapon> weapons, Const.Attribute attribute,
            HpParameter parameter)
            : base(weapons, attribute, parameter)
        {
        }
    }
}

