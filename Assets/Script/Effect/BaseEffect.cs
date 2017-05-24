using System.Collections.Generic;
using Script.Factories;
using Script.Maps;
using Script.Postions;
using UnityEngine;
using Zenject;

namespace Script.Effect
{
    public class BaseEffect : MonoBehaviour, IEffect
    {
        private Point _point;
        protected IMapTipsCore MapTips;

        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        public GameObject GameObject { get; private set; }

        [Inject]
        public void Construct(IMapTipsCore mapTips, List<RegistablesFactory<BaseEffect>> factories)
        {
            MapTips = mapTips;
        }

        public void RegisterOnMapTip()
        {
            MapTips.Register(this);
        }

        public void RemoveFromMapTip()
        {
            throw new System.NotImplementedException();
        }

        public void SetTransform()
        {
            transform.position = new Vector3(MapTipsCore.TipSize*Point.X, 1f, MapTipsCore.TipSize*Point.Y);
        }
    }
}
