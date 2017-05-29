using UniRx;

namespace Script.Maps
{
    public class MapTipsCollection : IMapTipsCollection
    {
        public const int MapSizeX = 15;
        public const int MapSizeY = 15;
        private BaseMapTip[,] _mapTips;
        private EffectsNum _effectsNum;
        private readonly Subject<EffectsNum> _effectsNumSubject = new Subject<EffectsNum>();
        public IObservable<EffectsNum> OnEffectsNumChanged { get { return _effectsNumSubject; }}


        public BaseMapTip GetMapTip(int x, int y)
        {
            return _mapTips[x,y];
        }

        public bool Enterable(int x, int y)
        {
            return y >= 0 && y < MapSizeY && x >= 0 && x < MapSizeX &&
                   GetMapTip(x, y).Enterable();
        }

        public void Initialize(BaseMapTip[,] mapTips)
        {
            _mapTips = mapTips;
            foreach (var tip in mapTips)
            {
                tip.OnIncreaseEffect.Subscribe(IncreaseEffect);
                tip.OnDecreaseEffect.Subscribe(DecreaseEffect);
            }
        }

        public EffectsNum EffectsNum { get { return _effectsNum; } }

        private void IncreaseEffect(Const.Attribute attribute)
        {
            switch (attribute)
            {
                case Const.Attribute.Fire:
                    _effectsNum.Fire++;
                    break;                                
                case Const.Attribute.Ice:
                    _effectsNum.Ice++;
                    break;
            }
            _effectsNumSubject.OnNext(_effectsNum);
        }
        
        private void DecreaseEffect(Const.Attribute attribute)
        {
            switch (attribute)
            {
                case Const.Attribute.Fire:
                    _effectsNum.Fire--;
                    break;                                
                case Const.Attribute.Ice:
                    _effectsNum.Ice--;
                    break;
            }
            _effectsNumSubject.OnNext(_effectsNum);
        }
    }
}

