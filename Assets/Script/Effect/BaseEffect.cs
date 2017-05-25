using System.Collections.Generic;
using Script.Attackers;
using Script.Factories;
using Script.Hits;
using Script.Maps;
using Script.Postions;
using Script.Weapons;
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

        public void Destroy()
        {
            Destroy(gameObject);
            RemoveFromMapTip();
        }

        public void SetTransform()
        {
            transform.position = new Vector3(MapTipsCore.TipSize*Point.X, 1f, MapTipsCore.TipSize*Point.Y);
        }

        public Const.Attribute Attribute
        {
            get { return _attribute; }
        }

        public bool Hit(IAttacker attacker, out HitInfo info)
        {
            if (attacker.Attribute == Attribute)
            {
                info = new HitInfo(this, attacker, false);
                return false;
            }
            info = new HitInfo(this, attacker, false);
            return true;

        }
    }
}
