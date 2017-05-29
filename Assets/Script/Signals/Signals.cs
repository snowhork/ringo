using Zenject;

namespace Script.Signals
{
    public class PlayerDiedSignal : Signal<int, PlayerDiedSignal>
    {     
    }
    
    public class SettlementSignal : Signal<int ,SettlementSignal>
    {
        
    }
        
    public class TimerEndSignal : Signal<TimerEndSignal>
    {
        
    }
}
