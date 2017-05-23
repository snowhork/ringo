using Script.Postions;
using UnityEngine;

namespace Script.Players
{
    public class PlayerAttackInput
    {
        public Point AttackInput()
        {
            if (Input.GetKey(KeyCode.D)) return new Point(1,  0);
            if (Input.GetKey(KeyCode.A))  return new Point(-1, 0);
            if (Input.GetKey(KeyCode.W))   return new Point(0, 1);
            if (Input.GetKey(KeyCode.S))   return new Point(0, -1);
            return new Point(0, 0);
        }
    }
}
