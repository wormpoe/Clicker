using UnityEngine;
using Zenject;

public class CountHolder
{
    private int _count = 1;
    public int Count { get =>  _count; }
    [Inject]
    private void Construct(SignalBus signalBus)
    {
        signalBus.Subscribe<CountUpgradeSignal>(OnCount);
    }
    private void OnCount(CountUpgradeSignal signal)
    {
        _count = signal.Value;
    }
}
