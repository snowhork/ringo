using Script.Blocks;
using Script.Bullets;
using Script.Effect;
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
        IBlock GetBlock(Point point);
        void Register(IItem registrable);
        void Register(IBlock registrable);
        void Register(IPlayer registrable);
        void Register(IBullet registrable);
        void Register(IEffect registrable);
        void Remove(IItem registrable);
        void Remove(IBlock registrable);
        void Remove(IPlayer registrable);
        void Remove(IBullet registrable);
        void Remove(IEffect registrable);
    }
}
