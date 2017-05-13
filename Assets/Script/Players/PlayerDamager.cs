using Script.Attackers;
using UnityEngine;

namespace Script.Players
{
    [RequireComponent(typeof(PlayerDamager))]
    public class PlayerDamager : MonoBehaviour
    {
        private PlayerParameter _parameter;

        private void Start()
        {
            _parameter = GetComponent<PlayerParameter>();
        }

        public void Execute(IAttacker attacker)
        {

        }
    }
}
