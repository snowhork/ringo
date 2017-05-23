using Script.Maps;

namespace Script.Blocks
{
    public interface IBlock : IRegistable
    {
        bool Hit();
    }
}
