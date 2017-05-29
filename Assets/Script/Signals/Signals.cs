using Zenject;

namespace Script.Signals
{
    public class PlayerDiedSignal : Signal<int, PlayerDiedSignal>
    {     
    }
    
    public class SettlementSignal : Signal<int ,SettlementSignal>
    {
        
    }
}
