using Script.Attackers;

namespace Script.Hits
{
    public struct HitInfo
    {
        private readonly IHittable _hittable;
        private readonly IAttacker _attacker;
        private readonly bool _hitsuccess;

        public bool Hitsuccess
        {
            get { return _hitsuccess; }
        }

        private readonly bool _hittableIsBroken;
        private readonly bool _attackerWillBroken;
        private readonly bool _bulletWillStopEffect;

        public IHittable Hittable
        {
            get { return _hittable; }
        }

        public IAttacker Attacker
        {
            get { return _attacker; }
        }

        public bool HittableIsBroken
        {
            get { return _hittableIsBroken; }
        }

        public bool AttackerWillBroken
        {
            get { return _attackerWillBroken; }
        }

        public bool BulletWillStopEffect
        {
            get { return _bulletWillStopEffect; }
        }

        public HitInfo(IHittable hittable, IAttacker attacker,
            bool hitsuccess,
            bool hittableIsBroken = false,
            bool attackerWillBroken = false,
            bool bulletWillStopEffect = false
            )
        {
            _hittable = hittable;
            _attacker = attacker;
            _hitsuccess = hitsuccess;
            _hittableIsBroken = hittableIsBroken;
            _attackerWillBroken = attackerWillBroken;
            _bulletWillStopEffect = bulletWillStopEffect;
        }
    }
}
