using Script.Attackers;
using Script.Maps;
using Zenject;

namespace Script.Blocks
{
    public class NormalBlock : BaseBlock
    {
        public override bool Hit(IAttacker attacker)
        {
            RemoveFromMapTip();
            Destroy(gameObject);
            return true;
        }
    }
}
