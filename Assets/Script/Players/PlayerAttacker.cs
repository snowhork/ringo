using Script.Attackers;
using Script.Characters;

namespace Script.Players
{
    public class PlayerAttacker : IAttacker
    {
        public PlayerAttacker(BaseCharacterParameter parameter)
        {
            _parameter = parameter;
        }

        private BaseCharacterParameter _parameter;


        public Const.Attribute Attribute
        {
            get { return _parameter.Attribute; }
        }
    }
}
