using Script.Characters;
using Script.Maps;
using Script.Postions;

namespace Script.Items
{
    public interface IItem : IRegistable
    {
        void Use(BaseCharacterParameter parameter);
    }
}
