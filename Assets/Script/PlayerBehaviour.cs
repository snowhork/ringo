using UnityEngine;

namespace Assets.Script
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private MapTipsBehaviour _mapTips;
        private PlayerInput _input;
        private PlayerMover _mover;

        private void Awake()
        {
            _mover = new PlayerMover(_mapTips);
        }

        private void Start()
        {
            _input = new PlayerInput();
        }

        private void Update()
        {
            var inputMove = _input.MoveInput();
            _mover.Move(inputMove);
            if (inputMove != Point.Zero())
            {
                Debug.Log(_mover.Point.ToString());
            }

            transform.position += new Vector3(inputMove.X*MapTipsBehaviour.TipSize, 0, inputMove.Y*MapTipsBehaviour.TipSize);
        }
    }
}
