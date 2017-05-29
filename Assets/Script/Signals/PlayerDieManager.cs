using System.Linq;
using UnityEngine;
using UniRx;

namespace Script.Signals
{
    public class PlayerDieManager
    {
        private readonly PlayerDiedSignal _playerDiedSignal;        
        private readonly SettlementSignal _settlementSignal;
        private readonly PlayerDiedInfo[] _playerDiedInfos;
        
        public PlayerDieManager(PlayerDiedSignal playerDiedSignal, SettlementSignal settlementSignal)        
        {
            _playerDiedSignal = playerDiedSignal;
            _settlementSignal = settlementSignal;
            _playerDiedSignal.AsObservable.Subscribe(PlayerDie);

            _playerDiedInfos = new PlayerDiedInfo[2];
            for (var i = 0; i < 2; i++)
            {
                _playerDiedInfos[i] = new PlayerDiedInfo(i, false);
            }
        }

        void PlayerDie(int playerNum)
        {
            _playerDiedInfos[playerNum].Died = true;
            if (_playerDiedInfos.Count(x => x.Survive) == 1)
            {
                var info = _playerDiedInfos.First(x => x.Survive);
                _settlementSignal.Fire(info.PlayerNum);
            }
        }
    
        struct PlayerDiedInfo
        {
            private int _playerNum;
            private bool _died;

            public int PlayerNum
            {
                get { return _playerNum; }
                set { _playerNum = value; }
            }

            public bool Died
            {
                get { return _died; }
                set { _died = value; }
            }
            
            public bool Survive
            {
                get { return !_died; }
            }

            public PlayerDiedInfo(int playerNum, bool died)
            {
                _playerNum = playerNum;
                _died = died;
            }
        }
    }
}
