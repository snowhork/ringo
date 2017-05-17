using Script.Postions;
using UnityEngine;

namespace Script.Players
{
    public class PlayerMoveInput : IMoveInput
    {
        public Point MoveInput()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)) return new Point(1,  0);
            if (Input.GetKeyDown(KeyCode.LeftArrow))  return new Point(-1, 0);
            if (Input.GetKeyDown(KeyCode.UpArrow))   return new Point(0, 1);
            if (Input.GetKeyDown(KeyCode.DownArrow))   return new Point(0, -1);
            return new Point(0, 0);
        }
    }
}
