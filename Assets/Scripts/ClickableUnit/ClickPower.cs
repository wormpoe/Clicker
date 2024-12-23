using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Zenject;

public class ClickPower : IPower
{
    private float _click = 1;
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
        _click += power / Mathf.Pow(10, _exponent - exponent);
        var result = _calculateLargeNumbers.Calculate(_click);
        _click = result.Item1;
        _exponent += result.Item2;
        _signalBus.Fire(new ClickPowerSignal(_click, _exponent));
    }
    public float GetPower()
    {
        return _click;
    }
    public int GetExponent()
    {
        return _exponent;
    }
}
