using UnityEngine;
using Zenject;

public class UpgradeClick : Upgrade
{
    private ClickPower _clickPower;
    private UpgradeData _upgradeData;
    private float _clickUpgrade;
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
        _exponent = _upgradeData.StartExponent;
        _scale = _upgradeData.Scale;
        _clickUpgrade = _upgradeData.Upgrade;
        _upgradeExponent = _upgradeData.UpgradeExponent;
        _tmpPrice = _price;
    }
    protected override void UpgradePower()
    {
        _clickPower.UpgradePower(_clickUpgrade * _tmpCount, _upgradeExponent);
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
