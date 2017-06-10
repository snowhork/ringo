using Script.Postions;

namespace Script.Players
{
    public interface IPlayerInput
    {
        Point LookInput();
        Point MoveInput();
        Point AttackInput();
        Point SpecialAttackInput();
    }
}
