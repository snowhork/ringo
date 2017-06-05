using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Script.Hits;
using Script.Maps;
using Script.Postions;
using UnityEngine;

namespace Script.Bullets
{
    public class CannonBullet : BaseBullet
    {
        
        [SerializeField] private AudioClip _clip;
        private void Start()
        {
            SoundManager.Play(_clip);
        }
        
        public override void Execute()
        {
            StartCoroutine(MoveCoroutine());
        }

        private float Speed
        {
            get { return 0.3f; }
        }

        private int Range
        {
            get { return 3; }
        }

        private IEnumerator MoveCoroutine()
        {
            var distance = 0;
            SetTransform();
            while (distance <= 3)
            {
                var startPos = transform.position;
                var delta = 0f;

                for (; delta <= BaseMapTip.TipSize / 2; delta += Speed)
                {
                    transform.position +=
                        new Vector3(AttackForward.X, 0, AttackForward.Y) * Speed;
                    yield return null;
                }
                if (!MoveProcess(AttackForward)) break;
                distance++;
                for (; delta <= BaseMapTip.TipSize; delta += Speed)
                {
                    transform.position +=
                        new Vector3(AttackForward.X, 0, AttackForward.Y) * Speed;
                    yield return null;
                }

                transform.position = startPos + new Vector3(AttackForward.X, 0, AttackForward.Y) * BaseMapTip.TipSize;
                if (MapTips.EnterableMapTip(Point))
                {
                    if (MapTips.GetEffect(Point) == null)
                    {
                        var effect = Factories[0].Create(Point);
                        effect.SetTransform();
                    }
                }
            }
            Destroy();
        }

        private bool MoveProcess(Point moveForward)
        {
            var nextPoint = Point + moveForward;
            if (!MapTips.EnterableMapTip(nextPoint)) return false;

            var player = MapTips.GetPlayer(nextPoint);
            var block = MapTips.GetBlock(nextPoint);
            var bullet = MapTips.GetBullet(nextPoint);
            var effect = MapTips.GetEffect(nextPoint);

            HitInfo info;

            if (player != null)
            {
                if (player.Hit(this, out info))
                {
                    Move(moveForward);
                    return false;
                }
            }
            if (block != null)
            {
                if (block.Hit(this, out info)) Move(moveForward);
                return false;
            }
            if (bullet != null)
            {
                bullet.Destroy();
                return false; // to do: このままだとeffectがつく
            }
            if (effect != null)
            {
//                if (effect.Hit(this, out info))
//                {
//                    Move(moveForward);
//                    return false;
//                }
            }


            Move(moveForward);
            return true;
        }
    }
}
