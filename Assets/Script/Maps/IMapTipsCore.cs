using Script.Creatures;
using Script.Items;
using Script.Players;
using Script.Postions;

namespace Script.Maps
{
    public interface IMapTipsCore
    {
        BaseMapTip GetMapTip(int x, int y);
        BaseMapTip GetMapTip(Point point);
        bool EnterableMapTip(Point point);
        IItem GetItem(Point point);
        IPlayer GetPlayer(Point point);
        ICreature GetCreature(Point point);
    }
}
