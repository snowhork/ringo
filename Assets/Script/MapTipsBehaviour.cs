using UnityEngine;

namespace Assets.Script
{
    public class MapTipsBehaviour : MonoBehaviour
    {
        public const float TipSize = 1f;
        private MapTipsCollection _mapTipsCollection;

        private void Awake()
        {
            _mapTipsCollection = new MapTipsCollection();
        }

        public BaseMapTip GetMapTip(int x, int y)
        {
            return _mapTipsCollection.GetMapTip(x, y);
        }
    }
}
