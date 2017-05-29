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

        public override void Use(BaseCharacterParameter parameter)
        {
            parameter.CoolTime -= _frequencyValue;
            Destroy();
        }
    }
}
