using System.Collections.Generic;
using Script.Blocks;
using Script.Effect;
using UniRx;
using Script.Factories;
using Script.Postions;
using UnityEngine;

namespace Script.Maps
{
    public class MapTipsCollection : IMapTipsCollection
    {
        public const int MapSizeX = 15;
        public const int MapSizeY = 15;
        private BaseMapTip[,] _mapTips;
        private int _fireEffectsNum;
        private int _iceEffectsNum;
        private readonly Subject<Tuple<int, int>> _effectsNumSubject = new Subject<Tuple<int, int>>();
        public IObservable<Tuple<int, int>> OnEffectsNumChanged { get { return _effectsNumSubject; }}

        public MapTipsCollection()
        {

        }

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

        private void IncreaseEffect(Const.Attribute attribute)
        {
            switch (attribute)
            {
                case Const.Attribute.Fire:
                    _fireEffectsNum++;
                    break;                                
                case Const.Attribute.Ice:
                    _iceEffectsNum++;
                    break;
            }
            _effectsNumSubject.OnNext(new Tuple<int, int>(_fireEffectsNum, _iceEffectsNum));
        }
        
        private void DecreaseEffect(Const.Attribute attribute)
        {
            switch (attribute)
            {
                case Const.Attribute.Fire:
                    _fireEffectsNum--;
                    break;                                
                case Const.Attribute.Ice:
                    _iceEffectsNum--;
                    break;
            }
            _effectsNumSubject.OnNext(new Tuple<int, int>(_fireEffectsNum, _iceEffectsNum));
        }
    }
}

