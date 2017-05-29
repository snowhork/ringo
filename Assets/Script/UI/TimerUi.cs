using Script.Characters;
using UniRx;
using UnityEngine;
using Zenject;

namespace Script.UI
{
    public class TimerUi : MonoBehaviour
    {
        [SerializeField] private Transform _timerBar;
        private Timer _timer;

        private void Start()
        {
            transform.parent = Camera.main.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
        
        [Inject]
        public void Construct(Timer timer)
        {
            _timer = timer;
        }

        private void Update()
        {
            _timerBar.localScale = new Vector3(_timer.RemainTime/Timer.MaxTime, 1f, 1f);
        }
    }
}
