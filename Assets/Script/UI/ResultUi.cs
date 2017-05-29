using Script.Characters;
using Script.Signals;
using UniRx;
using UnityEngine;
using Zenject;

namespace Script.UI
{
    public class ResultUi : MonoBehaviour
    {
        [SerializeField] private TextMesh _textMesh;
        private SettlementSignal _settlementSignal;

        [Inject]
        public void Construct(SettlementSignal settlementSignal)
        {
            _settlementSignal = settlementSignal;
            _settlementSignal.AsObservable.Subscribe(SetText);
        }
        
        private void Start()
        {
            transform.parent = Camera.main.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }

        public void SetText(int playerNum)
        {
            if (playerNum == -1)
            {
                _textMesh.text = "ドロー";
            }
            else if(playerNum == 0)
            {
                _textMesh.text = "炎側" + "の勝利！";
            }
            else if(playerNum == 1)
            {
                _textMesh.text = "氷側" + "の勝利！";
            }
        }
    }
}
