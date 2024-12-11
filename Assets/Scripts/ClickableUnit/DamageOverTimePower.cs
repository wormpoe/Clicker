using UnityEngine;
using Zenject;

public class DamageOverTimePower : IPower
{
    private int _dps = 0;
    private float _tickInterval = 1;
    private float _timer = 0;
    private SignalBus _signalBus;
    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    public void UpgradePower(int value)
    {
        _dps += value;
        _signalBus.Fire(new DPSPowerSignal(_dps));
    }
    public int GetPower()
    {
        _timer += Time.deltaTime;
        if (_timer >= _tickInterval)
        {
            _timer -= _tickInterval;
            return _dps;
        }
        return 0;
    }
}
