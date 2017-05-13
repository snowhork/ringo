using Script.Players;
using UnityEngine;

namespace Script.Items
{
    public class Portion : BaseItem
    {
        [SerializeField] private int _hpValue;
        public override void Use(PlayerParameter parameter)
        {
            parameter.Hp += _hpValue;
        }
    }
}
