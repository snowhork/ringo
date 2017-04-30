using System.Collections.Generic;
using Assets.Script;

public abstract class BaseMapTip : IPositionable
{
	protected Point _point;
	protected List<IMovable> _movables = new List<IMovable>();

	public Point Point
	{
		get { return _point; }
	}

	protected BaseMapTip(Point point)
	{
		_point = point;
	}

	public abstract bool Enterable();

	public void AddToList(IMovable movable)
	{
		_movables.Add(movable);
	}

	public void DeleteFromList(IMovable movable)
	{
		_movables.Remove(movable);
	}
}
