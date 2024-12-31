using Zenject;
public class ButtonClickUpgrade : ButtonUpgrade
{
    private ClickPower _clickPower;

    [Inject]
    protected void Construct(ClickPower clickPower)
    {
        _clickPower = clickPower;
    }
    protected override void SendPower()
    {
        _clickPower.UpgradeClick(_powerUpgradeMantissa, _powerUpgradeExponent);
    }
}
