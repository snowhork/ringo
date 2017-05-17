using Script.Characters;
using Script.Items;

namespace Script.Players
{
    public class PlayerItemGetter : IItemGetter
    {
        private readonly BaseCharacterParameter _parameter;

        public PlayerItemGetter(BaseCharacterParameter parameter)
        {
            _parameter = parameter;
        }

        public void Execute(IItem item)
        {
            item.Use(_parameter);
        }
    }
}
