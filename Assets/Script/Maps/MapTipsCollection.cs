using System.Collections.Generic;
using Script.Maps;

public class MapTipsCollection
{
    public const int MapRowsNum = 6;
    public const int MapColsNum = 12;
    private List<BaseMapTip>[] _mapTipsRows;

    public MapTipsCollection()
    {
        _mapTipsRows = new List<BaseMapTip>[MapRowsNum];
        for (var i = 0; i < MapRowsNum; i++)
        {
            _mapTipsRows[i] = new List<BaseMapTip>();
            for (var j = 0; j < MapColsNum; j++)
            {
                _mapTipsRows[i].Add(new NormalMapTip(i, j));
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

