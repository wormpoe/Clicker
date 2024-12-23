using UnityEngine;
using Zenject;

public class DamageOverTimePower : IPower
{
    protected float _dps = 0;
    protected int _exponent = 0;
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
        _dps += power / Mathf.Pow(10, _exponent - exponent);
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
    public Vector3 GenerationRandomPosition(Transform unit, Camera camera)
    {
        Vector3 pos = unit.transform.position;
        var canvasPos = RectTransformUtility.WorldToScreenPoint(camera, pos);
        int radius = Random.Range(30, 50);
        float radians = Random.Range(0, 360) * Mathf.Deg2Rad;
        canvasPos.x += radius * Mathf.Cos(radians);
        canvasPos.y += radius * Mathf.Sin(radians);
        return canvasPos;
    }
}
