using Script.Postions;
using UnityEngine;

namespace Script.Players
{
    public class PlayerMoveInput
    {
        public Point MoveInput()
        {
            if (Input.GetKey(KeyCode.RightArrow)) return new Point(1,  0);
            if (Input.GetKey(KeyCode.LeftArrow))  return new Point(-1, 0);
            if (Input.GetKey(KeyCode.UpArrow))   return new Point(0, 1);
            if (Input.GetKey(KeyCode.DownArrow))   return new Point(0, -1);
            return new Point(0, 0);
        }
    }
}
