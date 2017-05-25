using Script.Maps;
using Script.Postions;

namespace Script.Bullets
{
    public interface IBullet : IRegistable
    {
        void Execute();
    }
}
