using UnityEngine;
using Zenject;

public class UpgradeClick : Upgrade
{
    private ClickPower _clickPower;
    private UpgradeData _upgradeData;
    private int _clickUpgrade;
    [SerializeField] string upgradeName;
    [Inject]
    private void Construct(ClickPower clickPower)
    {
        _clickPower = clickPower;
    }
    protected override void Init(UpgradeConfig upgradeConfig)
    {
        _upgradeData = FindData(upgradeConfig);
        _price = _upgradeData.StartPrice;
        _scale = _upgradeData.Scale;
        _clickUpgrade = _upgradeData.Upgrade;
    }
    protected override void UpgradePower()
    {
        _clickPower.UpgradePower(_clickUpgrade);
    }
    private UpgradeData FindData(UpgradeConfig upgradeConfig)
    {
        foreach(var data in upgradeConfig.ClickUpgradeData)
        {
            if (data.Name == upgradeName)
            {
                return data;
            }
        }
        return upgradeConfig.ClickUpgradeData[0];
    }
}
