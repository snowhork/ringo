using Script.Maps;
using Script.Postions;
using Script.Weapons;
using UnityEngine;
using Zenject;

namespace Script.Bullets
{
    public abstract class BaseBullet : MonoBehaviour, IBullet
    {
        private Point _point;
        protected IMapTipsCore MapTips;
        private WeaponParameter _parameter;
        private Point _attackForward;

        public Point AttackForward
        {
            get { return _attackForward; }
            set { _attackForward = value; }
        }

        public WeaponParameter Parameter
        {
            get { return _parameter; }
            set { _parameter = value; }
        }

        [Inject]
        public void Construct(IMapTipsCore mapTips)
        {
            MapTips = mapTips;
        }

        public Point Point
        {
            get { return _point; } set { _point = value; }
        }

        Point IPositionable.Point
        {
            get { return Point; }
            set { Point = value; }
        }

        public GameObject GameObject
        {
            get { return gameObject; }
        }

        public void RegisterOnMapTip()
        {
            MapTips.Register(this);
        }

        public void RemoveFromMapTip()
        {
            MapTips.Remove(this);
        }

        public abstract void Execute();

        protected void Move(Point point)
        {
            RemoveFromMapTip();
            Point += point;
            RegisterOnMapTip();
        }

        public void SetTransform()
        {
            transform.position = new Vector3(MapTipsCore.TipSize*Point.X, 1f, MapTipsCore.TipSize*Point.Y);
        }
    }
}
