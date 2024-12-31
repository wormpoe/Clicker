using UnityEngine;

public class ClickPower : Power
{
    protected override void Init()
    {
        _powerMantissa = 1;
        _powerExponent = 0;
    }
    public void UpgradeClick(float power, int exponent)
    {
        CalculatePower(power, exponent);
        SendPowerInHud();
    }
    protected override void SendPowerInHud()
    {
        _signalBus.Fire(new ClickPowerSignal(_powerMantissa, _powerExponent));
    }
}
