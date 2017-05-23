using Script.Maps;
using Zenject;

namespace Script.Blocks
{
    public class NormalBlock : BaseBlock
    {
        public override bool Hit()
        {
            RemoveFromMapTip();
            Destroy(gameObject);
            return true;
        }
    }
}
