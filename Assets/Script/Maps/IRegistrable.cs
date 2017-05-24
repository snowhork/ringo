using Script.Postions;

namespace Script.Maps
{
    public interface IRegistable : IPositionable
    {
        void SetTransform();
        void RegisterOnMapTip();
        void RemoveFromMapTip();
    }
}
