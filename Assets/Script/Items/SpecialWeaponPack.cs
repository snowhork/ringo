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
        [SerializeField]
        private AudioClip _clip;
        public override void Use(BaseCharacterParameter parameter)
        {
            SoundManager.Play(_clip);            
            parameter.SpecialWeaponCount += 1;
            Destroy();
        }
    }
}
