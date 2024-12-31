using System.Collections.Generic;
using UnityEngine;

public class DpsPower : Power
{
    private Dictionary<string, DpsItem> _dpsItem = new Dictionary<string, DpsItem>();
    public Dictionary<string, DpsItem> DpsItem { get => _dpsItem; }
    protected override void Init()
    {
        _powerExponent = 0;
        _powerMantissa = 0;
    }
    public void InitItem(string name, float tickinterval)
    {
        if (!DpsItem.ContainsKey(name))
        {
            var newItem = new DpsItem();
            newItem.Init(tickinterval);
            _dpsItem[name] = newItem;
        }
    }
    public void UpgradeDpsItem(float mantissa, int exponent, string name)
    {
        _powerMantissa = _dpsItem[name].PowerMantissa;
        _powerExponent = _dpsItem[name].PowerExponent;
        CalculatePower(mantissa, exponent);
        _dpsItem[name].AddPower(_powerMantissa, _powerExponent);
        SendPowerInHud();
    }
    protected override void SendPowerInHud()
    {
        Init();
        foreach (var powerDps in _dpsItem.Values)
        {
            if (powerDps.PowerMantissa > 0)
            {
                CalculatePower(powerDps.PowerMantissa / powerDps.TickInterval, powerDps.PowerExponent);
            }
        }
        _signalBus.Fire(new DPSPowerSignal(_powerMantissa, _powerExponent));
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
