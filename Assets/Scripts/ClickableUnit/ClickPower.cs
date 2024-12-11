using UnityEngine;
using Zenject;

public class ClickPower : IPower
{
    private int _click = 1;
    private SignalBus _signalBus;

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    public void UpgradePower(int value)
    {
        _click += value;
        _signalBus.Fire(new ClickPowerSignal(_click));
    }
    public int GetPower()
    {
        return _click;
    }
}
