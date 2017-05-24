using System.Collections;
using Script.Maps;
using Script.Postions;
using UnityEngine;

namespace Script.Bullets
{
    public class BombBullet : BaseBullet
    {
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
            }
            RemoveFromMapTip();
            Destroy(gameObject);
            if (MapTips.EnterableMapTip(Point))
            {
                var effect = Factories[0].Create(Point);
                effect.SetTransform();
            }
        }

        private bool MoveProcess(Point moveForward)
        {
            var nextPoint = Point + moveForward;
            if (!MapTips.EnterableMapTip(nextPoint)) return false;

            var player = MapTips.GetPlayer(nextPoint);
            var block = MapTips.GetBlock(nextPoint);

            if (player != null)
            {
                if (player.Hit(this))
                {
                    Move(moveForward);
                    return false;
                }
            }
            if (block != null)
            {
                if (block.Hit(this)) Move(moveForward);
                return false;
            }
            Move(moveForward);
            return true;
        }
    }
}
