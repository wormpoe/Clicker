using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class NoobClickUpgrade : MonoBehaviour, IUpgradeble
{
    private int _upgradePrice;
    private float _scalePrice;
    private int _clickUpgrade;
    private int _countUpgrade;
    private GameScore _gameScore;
    private ClickPower _clickPower;
    private UpgradeConfig _upgradeConfig;
    private ClickUpgradeData _upgradeData;
    [SerializeField] Button upgradeButton;
    [SerializeField] TextMeshProUGUI textUpgradePrice;
    [SerializeField] TextMeshProUGUI textCountUpgrade;

    [Inject]
    private void Construct(GameScore gameScore, ClickPower clickPower, UpgradeConfig upgradeConfig)
    {
        _gameScore = gameScore;
        _clickPower = clickPower;
        _upgradeConfig = upgradeConfig;
    }
    private void Awake()
    {
        upgradeButton.onClick.AddListener(Upgrade);
        _upgradeData = _upgradeConfig.ClickUpgradeDatas[0];
        _upgradePrice = _upgradeData.StartPrice;
        _scalePrice = _upgradeData.Scale;
        _clickUpgrade = _upgradeData.ClickUpgrade;
        _countUpgrade = 0;
    }
    public void Upgrade()
    {
        if (_gameScore.GetScore >= _upgradePrice)
        {
            _gameScore.RemoveScore(_upgradePrice);
            _clickPower.UpgradePower(_clickUpgrade);
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
}
