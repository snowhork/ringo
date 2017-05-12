using Script.Items;

namespace Script.Players
{
    public class PlayerItemGetter
    {
        private readonly PlayerParameter _parameter;

        public PlayerItemGetter(PlayerParameter parameter)
        {
            _parameter = parameter;
        }

        public void Execute(IItem item)
        {
            item.Use(_parameter);
        }
    }
}
