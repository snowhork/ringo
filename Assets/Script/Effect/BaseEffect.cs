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
        private Const.Attribute _attribute;

        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        public GameObject GameObject
        {
            get { return gameObject; }
        }

        [Inject]
        public void Construct(IMapTipsCore mapTips, List<RegistablesFactory<BaseEffect>> factories, Const.Attribute attribute)
        {
            _attribute = attribute;
            MapTips = mapTips;
        }

        public void RegisterOnMapTip()
        {
            MapTips.Register(this);
        }

        public void RemoveFromMapTip()
        {
            MapTips.Register(this);
        }

        public void SetTransform()
        {
            transform.position = new Vector3(MapTipsCore.TipSize*Point.X, 1f, MapTipsCore.TipSize*Point.Y);
        }

        public Const.Attribute Attribute
        {
            get { return _attribute; }
        }
    }
}
