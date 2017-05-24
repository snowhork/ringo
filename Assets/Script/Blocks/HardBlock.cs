using Script.Attackers;
using Script.Maps;

namespace Script.Blocks
{
    public class HardBlock : BaseBlock
    {
        public override bool Hit(IAttacker attacker)
        {
            return false;
        }
    }
}
