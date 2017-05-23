using Script.Blocks;
using Script.Postions;

namespace Script.Maps
{
    public interface IMapTipsCollection
    {
        BaseMapTip GetMapTip(int x, int y);
        bool Enterable(int x, int y);
        void Initialize(BaseMapTip[,] mapTips);
    }
}
