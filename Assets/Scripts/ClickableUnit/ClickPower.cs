public class ClickPower : Power
{
    protected override void Init()
    {
        _powerMantissa = 1;
        _powerExponent = 0;
    }
    public override void UpgradePower(float power, int exponent)
    {
        base.UpgradePower(power, exponent);
        _signalBus.Fire(new ClickPowerSignal(_powerMantissa, _powerExponent));
    }
}
