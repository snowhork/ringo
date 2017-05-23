using Script.Postions;
using UnityEngine;

namespace Script.Effect
{
    public class BaseEffect : IEffect, MonoBehaviour
    {
        public Point Point { get; set; }
        public GameObject GameObject { get; private set; }
        public void RegisterOnMapTip()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveFromMapTip()
        {
            throw new System.NotImplementedException();
        }
    }
}
