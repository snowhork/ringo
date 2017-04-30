public class NormalMapTip : BaseMapTip
{
    public NormalMapTip(Point point) : base(point)
    {
    }

    public NormalMapTip(int x, int y) : base(new Point(x, y))
    {
    }

    public override bool Enterable()
    {
        return true;
    }
}

