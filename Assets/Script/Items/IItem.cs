using Script.Players;
using Script.Postions;

namespace Script.Items
{
    public interface IItem : IPositionable
    {
        void Use(PlayerParameter parameter);
    }
}
