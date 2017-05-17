using Script.Characters;
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
        protected IMapTipsCore MapTips;

        [Inject]
        public void Construct(IMapTipsCore mapTipsCore)
        {
            MapTips = mapTipsCore;
        }

        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        public abstract void Use(BaseCharacterParameter parameter);

        public void Initialize(Point point)
        {
            _point = point;
        }

        public void SetTransforn()
        {
            transform.position = new Vector3(BaseMapTip.TipSize*Point.X, 1f, BaseMapTip.TipSize*Point.Y);
        }

        private void OnDestroy()
        {
            MapTips.GetMapTip(Point).Remove(this);
        }

        public void RegisterOnMapTip()
        {
            MapTips.GetMapTip(Point).Register(this);
        }

        public void RemoveFromMapTip()
        {
            MapTips.GetMapTip(Point).Remove(this);
        }
    }
}
