using Script.Creatures;
using Script.Items;
using Script.Players;
using Script.Postions;

namespace Script.Maps
{
    public interface IMapTipsCore
    {
        bool EnterableMapTip(Point point);
        IItem GetItem(Point point);
        IPlayer GetPlayer(Point point);
        ICreature GetCreature(Point point);
        void Register(IItem registrable);
        void Register(ICreature registrable);
        void Register(IPlayer registrable);
        void Remove(IItem registrable);
        void Remove(ICreature registrable);
        void Remove(IPlayer registrable);
    }
}
