using UniRx;

namespace Script.Characters
{
    public interface IBehaviour
    {
        void Execute();
        IObservable<Unit> RemoveFromMapTip { get; }
        IObservable<Unit> RegisterOnMapTip { get; }
    }

}
