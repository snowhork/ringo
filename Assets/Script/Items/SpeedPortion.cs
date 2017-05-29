using Script.Characters;
using Script.Players;
using Script.Postions;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Script.Items
{
    public class SpeedPortion : BaseItem
    {
        [SerializeField] private float _speedValue;

        public override void Use(BaseCharacterParameter parameter)
        {
            parameter.Speed += _speedValue;
            Destroy();
        }
    }
}
