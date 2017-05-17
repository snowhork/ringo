using Script.Postions;

namespace Script.Maps
{
    public interface IRegistable : IPositionable
    {
        void RegisterOnMapTip();
        void RemoveFromMapTip();
    }
}
