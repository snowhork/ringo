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
        private int _colIndex = 0;
        private readonly List<BaseMapTip>[] _mapTipsRows;

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
            return _mapTipsRows[y][x];
        }

        public bool Enterable(int x, int y)
        {
            return y >= 0 && y < MapRowsNum && x >= 0 && x < _mapTipsRows[0].Count &&
                   _mapTipsRows[y][x].Enterable();
        }

        public void AppendCol(BaseMapTip[] tips)
        {
            for (var i = 0; i < MapRowsNum; i++)
            {
                tips[i].Point = new Point(_colIndex, i);
                tips[i].SetTransform();
                _mapTipsRows[i].Add(tips[i]);
            }
            _colIndex++;
        }

        public void RemoveCol()
        {
            return;
            for (var i = 0; i < MapRowsNum; i++)
            {
                Object.Destroy(_mapTipsRows[i][0]);
                _mapTipsRows[i].RemoveAt(0);
            }
        }
    }
}

