using Script.Maps;
using Script.Signals;
using UnityEngine;
using Zenject;

namespace Script
{
    public class Timer : ITickable
    {
        private float _remainTime;
        public const float MaxTime = 60f;
        private IMapTipsCollection _mapTipsCollection;
        private SettlementSignal _settlementSignal;
        private bool _timeOver;

        public Timer(IMapTipsCollection mapTipsCollection, SettlementSignal settlementSignal)
        {
            _remainTime = MaxTime;
            _mapTipsCollection = mapTipsCollection;
            _settlementSignal = settlementSignal;
        }

        public void Tick()
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime <= 0 && !_timeOver)
            {
                TimerEnd();
                _timeOver = true;
            }            
        }        

        public float RemainTime
        {
            get { return _remainTime; }
        }

        private void TimerEnd()
        {
            var fire = _mapTipsCollection.EffectsNum.Fire;
            var ice = _mapTipsCollection.EffectsNum.Ice;
            if(fire > ice) _settlementSignal.Fire((int)Const.Attribute.Fire);
            else if(ice > fire) _settlementSignal.Fire((int)Const.Attribute.Ice);
            else     _settlementSignal.Fire(-1);
        }
     }
}
