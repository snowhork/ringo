using Script.Players;
using Script.Postions;
using UnityEngine;

namespace Script.Items
{
    public class Portion : BaseItem
    {
        [SerializeField] private int _hpValue;

        private void Start()
        {
            Point = new Point(2,2);
            transform.position = new Vector3() + new Vector3(-0.5f, 0, -0.5f);
        }

        public override void Use(PlayerParameter parameter)
        {
            parameter.Hp += _hpValue;
        }
    }
}
