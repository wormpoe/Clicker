public class ShowDps : Revealed
{
    protected override void Init(UpgradeConfig upgradeConfig)
    {
        _upgradeData = upgradeConfig.DpsUpgradeData;
    }
}
