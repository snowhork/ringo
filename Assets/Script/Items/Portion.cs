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


        private void Start()
        {
//            this.UpdateAsObservable().Take(1)
//                .Subscribe(_ =>
//                {
//                    _point = new Point(Random.Range(0, 10), Random.Range(0, 5));
//                    MapTips.GetMapTip(Point).Register(this);
//                    SetTransforn();
//                });
        }

        public override void Use(BaseCharacterParameter parameter)
        {
            parameter.Hp += _hpValue;
            Destroy(gameObject);
        }
    }
}
