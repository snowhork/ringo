
using Script.Attackers;
using Script.Maps;
using Script.Postions;
using UnityEngine;

namespace Script.Players
{
    public class PlayerCore : MonoBehaviour, IPlayer
    {
        [SerializeField] private MapTipsBehaviour _mapTips;

        private PlayerParameter _parameter;
        private PlayerBehaviour _behaviour;
        private PlayerDamager _damager;

        private void Start()
        {
            _parameter = new PlayerParameter();
            _mapTips.GetMapTip(Point).Register(this);
            _behaviour = new PlayerBehaviour(this, _mapTips, _parameter);
            _damager = new PlayerDamager(_parameter);
        }

        private void Update()
        {
            _behaviour.Execute();
        }

        public Point Point
        {
            get { return _parameter.Point; }
            set { _parameter.Point = value; }
        }

        public Transform Transform
        {
            get { return transform; }
        }

        public void Damage(IAttacker attacker)
        {
            _damager.Execute(attacker);
        }
    }
}
