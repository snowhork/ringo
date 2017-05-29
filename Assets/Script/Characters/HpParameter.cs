using Script.Signals;
using UniRx;

namespace Script.Characters
{
    public class HpParameter
    {
        private IntReactiveProperty _hp = new IntReactiveProperty(3);
        private readonly PlayerDiedSignal _playerDiedSignal;
        private readonly Const.Attribute _attribute;
        private readonly Subject<Unit> _diedSubject = new Subject<Unit>();

        public HpParameter(PlayerDiedSignal playerDiedSignal, Const.Attribute attribute)
        {
            _playerDiedSignal = playerDiedSignal;
            _attribute = attribute;
        }

        public IObservable<int> OnHpChanged
        {
            get { return _hp; }
        }

        public IObservable<Unit> OnDied
        {
            get { return _diedSubject; }
        }
        
        public int Hp
        {
            get { return _hp.Value; }
            set
            {
                _hp.Value = value;
                if (_hp.Value <= 0)
                {
                    _playerDiedSignal.Fire((int)_attribute);
                    _diedSubject.OnNext(Unit.Default);
                }
            }
        }
    }
}
