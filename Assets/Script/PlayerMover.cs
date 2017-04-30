namespace Assets.Script
{
    public class PlayerMover : IMovable
    {
        public PlayerMover(MapTipsBehaviour mapTips)
        {
            _mapTips = mapTips;
            MapTip.AddToList(this);
        }

        private readonly MapTipsBehaviour _mapTips;
        Point _point = new Point(0, 0);

        private BaseMapTip MapTip
        {
            get { return _mapTips.GetMapTip(Point.X, Point.Y); }
        }

        public Point Point
        {
            get { return _point; }
        }

        public void Move(Point point)
        {
            MapTip.DeleteFromList(this);
            _point += point;
            MapTip.AddToList(this);
        }
    }
}
