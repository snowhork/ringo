using Script.Attackers;
using Script.Hits;
using Script.Maps;

namespace Script.Blocks
{
    public class HardBlock : BaseBlock
    {
        public override bool Hit(IAttacker attacker, out HitInfo info)
        {
            info = new HitInfo(this, attacker, true, hittableIsBroken: false);
            return true;
        }
        
        public override bool Destroyable { get { return false; } }
    }
}
