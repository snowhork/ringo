using System.Collections.Generic;
using Script.Factories;
using Script.Postions;
using UnityEngine;

namespace Script.Maps
{
    public class MapTipsCollection : IMapTipsCollection
    {
        public const int MapRowsNum = 6;
        public const int MapColsNum = 12;
        private int _colStartIndex = 0;
        private int _colEndIndex = 0;
        private readonly List<BaseMapTip>[] _mapTipsRows;

        public int ColStartIndex
        {
            get { return _colStartIndex; }
        }

        public int ColEndIndex
        {
            get { return _colEndIndex; }
        }

        public MapTipsCollection()
        {
            _mapTipsRows = new List<BaseMapTip>[MapRowsNum];
            for (var i = 0; i < MapRowsNum; i++)
            {
                _mapTipsRows[i] = new List<BaseMapTip>();
            }
        }

        public BaseMapTip GetMapTip(int x, int y)
        {
            return _mapTipsRows[y][x - _colStartIndex];
        }

        public bool Enterable(int x, int y)
        {
            return y >= 0 && y < MapRowsNum && x >= _colStartIndex && x < _colEndIndex &&
                   GetMapTip(x, y).Enterable();
        }

        public void AppendCol(BaseMapTip[] tips)
        {
            for (var i = 0; i < MapRowsNum; i++)
            {
                tips[i].Point = new Point(_colEndIndex, i);
                tips[i].SetTransform();
                _mapTipsRows[i].Add(tips[i]);
            }
            _colEndIndex++;
        }

        public void RemoveCol()
        {
            for (var i = 0; i < MapRowsNum; i++)
            {
                var tip = _mapTipsRows[i][0];
                Object.Destroy(tip);
                _mapTipsRows[i].RemoveAt(0);
            }
            _colStartIndex++;
        }
    }
}

