using Script.Maps;
using Script.Postions;
using UnityEngine;
using Zenject;

namespace Script.Blocks
{
    public abstract class BaseBlock : MonoBehaviour, IBlock
    {
        private IMapTipsCore _mapTipsCore;
        private Point _point;

        [Inject]
        public void Construct(IMapTipsCore mapTipsCore)
        {
            _mapTipsCore = mapTipsCore;
        }

        public Point Point
        {
            get { return _point; }
            set { _point = value;  }
        }

        public GameObject GameObject
        {
            get { return gameObject; }
        }

        public void RegisterOnMapTip()
        {
            _mapTipsCore.Register(this);
        }

        public void RemoveFromMapTip()
        {
            _mapTipsCore.Remove(this);
        }

        public void SetTransform()
        {
            transform.position = new Vector3(MapTipsCore.TipSize*Point.X, 1f, MapTipsCore.TipSize*Point.Y);
        }

        public abstract bool Hit();
    }
}
