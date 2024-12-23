using UnityEngine;
using Zenject;

public class UpgradeDps : Upgrade
{
    private DamageOverTimePower _dpsPower;
    private UpgradeData _upgradeData;
    private float _dpsUpgrade;
    [SerializeField] string upgradeName;
    [Inject]
    private void Construct(DamageOverTimePower dpsPower)
    {
        _dpsPower = dpsPower;
    }
    protected override void Init(UpgradeConfig upgradeConfig)
    {
        _upgradeData = FindData(upgradeConfig);
        _price = _upgradeData.StartPrice;
        _exponent = _upgradeData.StartExponent;
        _scale = _upgradeData.Scale;
        _dpsUpgrade = _upgradeData.Upgrade;
        _upgradeExponent = _upgradeData.UpgradeExponent;
        _tmpPrice = _price;
    }
    protected override void UpgradePower()
    {
        _dpsPower.UpgradePower(_dpsUpgrade * _tmpCount, _upgradeExponent);
    }
    private UpgradeData FindData(UpgradeConfig upgradeConfig)
    {
        foreach (var data in upgradeConfig.DpsUpgradeData)
        {
            if (data.Name == upgradeName)
            {
                return data;
            }
        }
        return upgradeConfig.DpsUpgradeData[0];
    }
}
