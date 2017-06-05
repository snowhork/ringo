using Script.Hits;
using Script.Maps;

namespace Script.Blocks
{
    public interface IBlock : IRegistable, IHittable
    {
        bool Destroyable { get; }
    }
}
