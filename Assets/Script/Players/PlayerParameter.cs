using Script.Postions;

namespace Script.Players
{
    public class PlayerParameter
    {
        private Point _point = new Point(0,0);

        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }
    }
}
