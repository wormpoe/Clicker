using UnityEngine;
using Zenject;

public abstract class Power
{
    protected float _powerMantissa;
    protected int _powerExponent;
    protected SignalBus _signalBus;
    private CalculateLargeNumbers _calculateLargeNumbers;

    [Inject]
    private void Construct(SignalBus signalBus, CalculateLargeNumbers calculateLargeNumbers)
    {
        _signalBus = signalBus;
        _calculateLargeNumbers = calculateLargeNumbers;
        Init();
    }
    protected abstract void SendPowerInHud();
    protected void CalculatePower(float mantissa, int exponent)
    {
        _powerMantissa += mantissa / Mathf.Pow(10, _powerExponent - exponent);
        var result = _calculateLargeNumbers.Calculate(_powerMantissa);
        _powerMantissa = result.Item1;
        _powerExponent += result.Item2;
    }
    protected abstract void Init();
    public float GetPower()
    {
        return _powerMantissa;
    }
    public int GetExponent()
    {
        return _powerExponent;
    }
}
