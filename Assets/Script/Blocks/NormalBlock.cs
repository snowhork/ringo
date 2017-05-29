using Script.Attackers;
using Script.Hits;
using Script.Maps;
using Zenject;

namespace Script.Blocks
{
    public class NormalBlock : BaseBlock
    {
        public override bool Hit(IAttacker attacker, out HitInfo info)
        {
            RemoveFromMapTip();
            Destroy(gameObject);
            //SpawnItem();
            info = new HitInfo(this, attacker, true, hittableIsBroken: true);
            return true;
        }
    }
}
