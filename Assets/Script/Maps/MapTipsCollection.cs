using System.Collections.Generic;
using Script.Factories;
using Script.Postions;

namespace Script.Maps
{
    public class MapTipsCollection
    {
        public const int MapRowsNum = 6;
        public const int MapColsNum = 12;
        private List<BaseMapTip>[] _mapTipsRows;
        private readonly List<MapTipsFactory> _factories;

        public MapTipsCollection(List<MapTipsFactory> factories)
        {
            _factories = factories;
            MapTipsInitialize();
        }

        private void MapTipsInitialize()
        {
            _mapTipsRows = new List<BaseMapTip>[MapRowsNum];
            for (var i = 0; i < MapRowsNum; i++)
            {
                _mapTipsRows[i] = new List<BaseMapTip>();
                for (var j = 0; j < MapColsNum; j++)
                {
                    var tip = _factories[0].Create(new Point(j, i));
                    tip.SetTransforn();
                    _mapTipsRows[i].Add(tip);
                }
            }
        }

        public BaseMapTip GetMapTip(int x, int y)
        {
            return _mapTipsRows[y][x];
        }

        public bool Enterable(int x, int y)
        {
            return y >= 0 && y < MapRowsNum && x >= 0 && x < MapColsNum &&
                   _mapTipsRows[y][x].Enterable();
        }
    }
}

