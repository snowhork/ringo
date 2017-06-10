using System;
using Script.UI;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;


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
            Observable.Return(Unit.Default)
                .Delay(TimeSpan.FromSeconds(3f))
                .Subscribe(_ => SceneManager.LoadScene("main"));
        }
    }
}
