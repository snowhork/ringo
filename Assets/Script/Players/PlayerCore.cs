using Script.Attackers;
using Script.Maps;
using Script.Postions;
using UnityEngine;
using Zenject;

namespace Script.Players
{
    [RequireComponent(typeof(PlayerParameter), typeof(PlayerBehaviour), typeof(PlayerDamager))]
    public class PlayerCore : MonoBehaviour, IPlayer
    {
        [Inject] private MapTipsCore _mapTips;

        private PlayerParameter _parameter;
        private PlayerBehaviour _behaviour;
        private PlayerDamager _damager;

        private Point _point;

        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        private void Start()
        {
            _point = new Point(0,0);
            _parameter = GetComponent<PlayerParameter>();
            _behaviour = GetComponent<PlayerBehaviour>();
            _damager = GetComponent<PlayerDamager>();
            _mapTips.GetMapTip(Point).Register(this);
        }

        private void Update()
        {
            _behaviour.Execute();
        }

        public Transform Transform
        {
            get { return transform; }
        }

        public void Damage(IAttacker attacker)
        {
            _damager.Execute(attacker);
        }

        public void SetTransforn()
        {
            transform.position = new Vector3(BaseMapTip.TipSize*Point.X, 0, BaseMapTip.TipSize*Point.Y);
        }

    }
}
