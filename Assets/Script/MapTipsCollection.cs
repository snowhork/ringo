using System.Collections.Generic;

public class MapTipsCollection
{
    public const int MapRowsNum = 6;
    private List<BaseMapTip>[] _mapTipsRows;

    public MapTipsCollection()
    {
        _mapTipsRows = new List<BaseMapTip>[MapRowsNum];
        for (var i = 0; i < MapRowsNum; i++)
        {
            _mapTipsRows[i] = new List<BaseMapTip>();
            for (var j = 0; j < 12; j++)
            {
                _mapTipsRows[i].Add(new NormalMapTip(i, j));
            }
        }
    }

    public BaseMapTip GetMapTip(int x, int y)
    {
        return _mapTipsRows[y][x];
    }
}

