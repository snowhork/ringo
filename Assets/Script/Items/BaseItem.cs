using Script.Players;
using Script.Postions;
using UnityEngine;

namespace Script.Items
{
    public abstract class BaseItem : MonoBehaviour, IItem
    {
        private Point _point;

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
    }
}
