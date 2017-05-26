using Script.Postions;
using UnityEngine;

namespace Script.Players
{
    public class PlayerInputByJoyCon : IPlayerInput
    {
        private int _id;

        public PlayerInputByJoyCon(int id)
        {
            _id = id;
        }

        public Point MoveInput()
        {
            if (Input.GetAxis("Horizontal" + _id) > 0) return new Point(1,  0);
            if (Input.GetAxis("Horizontal" + _id) < 0)  return new Point(-1, 0);
            if (Input.GetAxis("Vertical" + _id) > 0)   return new Point(0, 1);
            if (Input.GetAxis("Vertical" + _id) < 0)    return new Point(0, -1);
            return new Point(0, 0);
        }

        public Point AttackInput()
        {
            if (Input.GetButtonDown("UpButton" + _id)) return new Point(0, 1);
            if (Input.GetButtonDown("DownButton" + _id)) return new Point(0, -1);
            if (Input.GetButtonDown("RightButton" + _id)) return new Point(1, 0);
            if (Input.GetButtonDown("LeftButton" + _id)) return new Point(-1, 0);
            return new Point(0, 0);
        }
    }
}
