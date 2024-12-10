using UnityEngine;
using Zenject;

public class ClickPower
{
    private int _click = 1;
    private SignalBus _signalBus;
    public int Click { get => _click; }

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    public void ClickUpdate(int value)
    {
        _click += value;
        _signalBus.Fire(new ClickPowerSignal(_click));
    }
}
