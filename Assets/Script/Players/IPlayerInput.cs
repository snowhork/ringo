using Script.Postions;

namespace Script.Players
{
    public interface IPlayerInput
    {
        Point MoveInput();
        Point AttackInput();
    }
}
