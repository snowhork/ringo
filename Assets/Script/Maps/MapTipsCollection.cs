using System.Collections.Generic;
using Script.Blocks;
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
        }
    }
}

