using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class NoobDPSUpgrade : MonoBehaviour, IUpgradeble
{
    private int _upgradePrice;
    private int _countUpgrade;
    private float _scalePrice;
    private int _dpsUpgrade;
    private GameScore _gameScore;
    private DamageOverTimePower _dpsPower;
    private DpsUpgradeData _upgradeData;
    private UpgradeConfig _upgradeConfig;
    [SerializeField] Button upgradeButton;
    [SerializeField] TextMeshProUGUI textUpgradePrice;
    [SerializeField] TextMeshProUGUI textCountUpgrade;

    [Inject]
    private void Construct(GameScore gameScore, DamageOverTimePower dpsPower, UpgradeConfig upgradeConfig)
    {
        _gameScore = gameScore;
        _dpsPower = dpsPower;
        _upgradeConfig = upgradeConfig;
    }
    private void Awake()
    {
        upgradeButton.onClick.AddListener(Upgrade);
        _upgradeData = _upgradeConfig.DpsUpgradeData[0];
        _upgradePrice = _upgradeData.StartPrice;
        _scalePrice = _upgradeData.Scale;
        _dpsUpgrade = _upgradeData.DpsUpgrade;
        _countUpgrade = 0;
    }
    public void Upgrade()
    {
        if (_gameScore.GetScore >= _upgradePrice)
        {
            _gameScore.RemoveScore(_upgradePrice);
            _dpsPower.UpgradePower(_dpsUpgrade);
            ScalePrice();
        }
    }
    public void ScalePrice()
    {
        _upgradePrice = (int)(_upgradePrice * _scalePrice);
        _countUpgrade++;
        textCountUpgrade.text = string.Format("x{0}", _countUpgrade);
        textUpgradePrice.text = string.Format("Price: {0}", _upgradePrice);
    }
    public void RevealedUpgrade(GameObject revealObject)
    {
        if (_gameScore.GetScore < _upgradePrice)
            return;
        revealObject.SetActive(true);
    }
}
