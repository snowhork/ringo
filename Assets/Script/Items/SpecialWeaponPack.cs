using Script.Characters;
using Script.Players;
using Script.Postions;
using Script.Weapons;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Script.Maps;

namespace Script.Items
{
    public class SpecialWeaponPack : BaseItem
    {
       IWeapon _specialWeapon;

        [Inject]
        public void Construct(IMapTipsCore mapTipsCore, ISpecialWeapon specialWeapon)
        {
            _specialWeapon = specialWeapon;
			base.Construct(mapTipsCore);
        }

        public override void Use(BaseCharacterParameter parameter)
        {
            parameter.SpecialWeaponCount += 1;
            Destroy();
        }
    }
}
