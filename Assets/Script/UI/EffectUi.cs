using Script.Characters;
using Script.Maps;
using UniRx;
using UnityEngine;
using Zenject;

namespace Script.UI
{
    public class EffectUi : MonoBehaviour
    {
        [SerializeField] private GameObject _fireTip;
        [SerializeField] private GameObject _iceTip;

        [SerializeField] private Transform _fireEffectPosition;
        [SerializeField] private Transform _iceEffectPosition;

        [SerializeField] private float _tipWidth = 0.1f;

        [SerializeField] private int _tipsNum = 30;

        private Renderer[] _fireRenders;
        private Renderer[] _iceRenders;

        [Inject]
        public void Construct(IMapTipsCollection collection)
        {
            collection.OnEffectsNumChanged.Subscribe(OnEffectsNumChanged);
            _fireRenders = new Renderer[_tipsNum];
            _iceRenders = new Renderer[_tipsNum];
        }
        
        private void Start()
        {
            transform.parent = Camera.main.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            for (var i = 0; i < _tipsNum; i++)
            {
                var tip = Instantiate(_fireTip);
                tip.transform.parent = _fireEffectPosition;
                tip.transform.localPosition = new Vector3(_tipWidth*i, 0, 0);
                tip.transform.localRotation = Quaternion.identity;
                _fireRenders[i] = tip.GetComponent<Renderer>();
                _fireRenders[i].enabled = false;
            }
            for (var i = 0; i < _tipsNum; i++)
            {
                var tip = Instantiate(_iceTip);
                tip.transform.parent = _iceEffectPosition;
                tip.transform.localPosition = new Vector3(_tipWidth*i, 0, 0);
                tip.transform.localRotation = Quaternion.identity;
                _iceRenders[i] = tip.GetComponent<Renderer>();
                _iceRenders[i].enabled = false;
            }
        }

        private void OnEffectsNumChanged(Tuple<int, int> tuple)
        {
            var fireNum = tuple.Item1;
            var iceNum = tuple.Item2;
            for (var i = 0; i < _tipsNum; i++)
            {
                _fireRenders[i].enabled = i < fireNum;
                _iceRenders[i].enabled = i < iceNum;
            }
  
        }
    }
}
