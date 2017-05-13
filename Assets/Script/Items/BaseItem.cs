using Script.Maps;
using Script.Players;
using Script.Postions;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Script.Items
{
    public abstract class BaseItem : MonoBehaviour, IItem
    {
        protected Point _point;
        [Inject] protected MapTipsCore MapTips;

        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        public abstract void Use(PlayerParameter parameter);

        public void Initialize(Point point)
        {
            _point = point;
        }

        private IObservable<Unit> _firstObservable;

        public void SetTransforn()
        {
            transform.position = new Vector3(BaseMapTip.TipSize*Point.X, 1f, BaseMapTip.TipSize*Point.Y);
        }

        private void OnDestroy()
        {
            MapTips.GetMapTip(Point).Remove(this);
        }
    }
}
