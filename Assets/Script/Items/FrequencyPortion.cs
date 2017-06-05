using Script.Characters;
using Script.Players;
using Script.Postions;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Script.Items
{
    public class FrequencyPortion : BaseItem
    {
        [SerializeField] private float _frequencyValue;
        
        [SerializeField]
        private AudioClip _clip;

        public override void Use(BaseCharacterParameter parameter)
        {
            SoundManager.Play(_clip);            
            parameter.CoolTime -= _frequencyValue;
            Destroy();
        }
    }
}
