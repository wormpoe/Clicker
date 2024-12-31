using UnityEngine;
using Zenject;

public class ButtonDpsUpgrade : ButtonUpgrade
{
    private DpsPower _dpsPower;
    [SerializeField] private float _tickInterval;

    [Inject]
    protected void Construct(DpsPower dpsPower)
    {
        _dpsPower = dpsPower;
    }
    protected override void SendPower()
    {
        _dpsPower.InitItem(_upgradeName, _tickInterval);
        _dpsPower.UpgradeDpsItem(_powerUpgradeMantissa * _tempCount, _powerUpgradeExponent, _upgradeName);
    }
}
