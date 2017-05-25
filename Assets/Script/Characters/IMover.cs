using Script.Postions;
using UniRx;

namespace Script.Characters
{
    public interface IMover
    {
        void Execute(Point point);
        IObservable<Unit> RemoveFromMapTip { get; }
        IObservable<Unit> RegisterOnMapTip { get; }
    }
}
