namespace Script.Maps
{
    public interface IMapTipsCollection
    {
        BaseMapTip GetMapTip(int x, int y);
        bool Enterable(int x, int y);
        void AppendCol(BaseMapTip[] tip);
        void RemoveCol();
        int ColStartIndex { get; }
        int ColEndIndex { get; }
    }
}
