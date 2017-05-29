using Script.Blocks;
using Script.Postions;
using UniRx;

namespace Script.Maps
{
    public interface IMapTipsCollection
    {
        BaseMapTip GetMapTip(int x, int y);
        bool Enterable(int x, int y);
        void Initialize(BaseMapTip[,] mapTips);
        EffectsNum EffectsNum { get; }
        IObservable<EffectsNum> OnEffectsNumChanged { get; }
        
    }
    
    
    public struct EffectsNum
    {
        private int _fire;
        private int _ice;

        public EffectsNum(int fire, int ice)
        {
            _fire = fire;
            _ice = ice;
        }

        public int Fire
        {
            get { return _fire; }
            set { _fire = value; }
        }

        public int Ice
        {
            get { return _ice; }
            set { _ice = value; }
        }
    }
}
