﻿using Script.Characters;
using Script.Maps;
using Script.Postions;
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
            MapTips.Remove(this);
        }

        public void RegisterOnMapTip()
        {
            MapTips.Register(this);
        }

        public void RemoveFromMapTip()
        {
            MapTips.Remove(this);
        }
    }
}
