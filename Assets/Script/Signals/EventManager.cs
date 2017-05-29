using UnityEngine;
using UniRx;


namespace Script.Signals
{
    public class EventManager
    {
        private SettlementSignal _settlementSignal;

        public EventManager(SettlementSignal settlementSignal)
        {
            _settlementSignal = settlementSignal;
            _settlementSignal.AsObservable.Subscribe(Settlement);
        }

        void Settlement(int playerNum)
        {
            if (playerNum == -1)
            {
                Debug.Log("ドロー");
            }
            else
            {
                Debug.Log(playerNum + "の勝利！");
            }
        }
    }
}
