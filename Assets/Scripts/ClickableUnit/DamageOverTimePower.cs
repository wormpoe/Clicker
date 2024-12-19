using UnityEngine;
using Zenject;

public class DamageOverTimePower : IPower
{
    private float _dps = 0;
    private int _exponent = 0;
    private SignalBus _signalBus;
    private CalculateLargeNumbers _calculateLargeNumbers;
    [Inject]
    private void Construct(SignalBus signalBus, CalculateLargeNumbers calculateLargeNumbers)
    {
        _signalBus = signalBus;
        _calculateLargeNumbers = calculateLargeNumbers;
    }
    public void UpgradePower(float power, int exponent)
    {
        _dps += power / Mathf.Pow(10, _exponent);
        var result = _calculateLargeNumbers.Calculate(_dps);
        _dps = result.Item1;
        _exponent += result.Item2;
        _signalBus.Fire(new DPSPowerSignal(_dps, _exponent));
    }
    public float GetPower()
    {
        return _dps;
    }
    public int GetExponent()
    {
        return _exponent;
    }
}
