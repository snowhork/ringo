using System.Collections.Generic;
using Script.Characters;
using Script.UI;
using Script.Weapons;

namespace Script.Players
{
    public class PlayerParameter : BaseCharacterParameter
    {
        public PlayerParameter(List<IWeapon> weapons, Const.Attribute attribute, HeartUi ui)
            : base(weapons, attribute, ui)
        {
        }
    }
}
