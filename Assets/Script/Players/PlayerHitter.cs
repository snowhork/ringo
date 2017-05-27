using System.Collections;
using UnityEngine;
using Script.Attackers;
using Script.Characters;
using Script.Hits;
using UniRx;

namespace Script.Players
{
    public class PlayerHitter : IHittable
    {
        private readonly BaseCharacterParameter _parameter;
        private readonly Renderer _renderer;
        private bool _invicible;

        public PlayerHitter(BaseCharacterParameter parameter, Renderer renderer)
        {
            _parameter = parameter;
            _renderer = renderer;
        }

        public bool Hit(IAttacker attacker, out HitInfo info)
        {
            if (_parameter.Attribute == attacker.Attribute || _invicible)
            {
                info = new HitInfo(this, attacker, false);
                return false;
            }
            _parameter.Hp--;
            Observable.FromCoroutine(Flash).Subscribe();
            info = new HitInfo(this, attacker, true);
            return true;
        }

        private IEnumerator Flash()
        {
            _invicible = true;
            for (var time = 0; time < 6; time++)
            {
                _renderer.enabled = false;
                yield return new WaitForSeconds(0.1f);
                _renderer.enabled = true;
                yield return new WaitForSeconds(0.1f);

            }
            _invicible = false;
        }
    }
}
