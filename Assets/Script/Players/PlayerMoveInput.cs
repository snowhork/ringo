using Script.Postions;
using UnityEngine;

namespace Script.Players
{
    public class PlayerMoveInput
    {
        public Point MoveInput()
        {
            var point = new Point(0, 0);
            if (Input.GetKey(KeyCode.RightArrow)) point = new Point(1,  0);
            if (Input.GetKey(KeyCode.LeftArrow))  point = new Point(-1, 0);
            if (Input.GetKey(KeyCode.UpArrow))   point = new Point(0, 1);
            if (Input.GetKey(KeyCode.DownArrow))   point = new Point(0, -1);

            var i = (int)PhotonNetwork.room.customProperties["PositionNumber"];
            if (point != Point.Zero())
            {
                GameObject.Find("sync" + i).GetComponent<SyncInput>().Point = point;
            }
            return point;
        }
    }
}
