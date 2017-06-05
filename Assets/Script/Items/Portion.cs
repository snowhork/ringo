using Script.Characters;
using Script.Players;
using Script.Postions;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Script.Items
{
    public class Portion : BaseItem
    {
        [SerializeField] private int _hpValue;

        [SerializeField]
        private AudioClip _clip;

        public override void Use(BaseCharacterParameter parameter)
        {
            SoundManager.Play(_clip);
            parameter.Hp += _hpValue;
            Destroy();
        }
    }
}
