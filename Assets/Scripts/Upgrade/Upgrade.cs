using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public abstract class Upgrade : MonoBehaviour
{
    protected int _price;
    protected float _scale;
    protected int _upgrade;
    protected int _count;
    private GameScore _gameScore;
    private UpgradeConfig _upgradeConfig;
    [SerializeField] protected Button upgradeButton;
    [SerializeField] protected TextMeshProUGUI textUpgradePrice;
    [SerializeField] protected TextMeshProUGUI textCountUpgrade;

    [Inject]
    private void Construct(GameScore gameScore, UpgradeConfig upgradeConfig)
    {
        _gameScore = gameScore;
        _upgradeConfig = upgradeConfig;
    }

    private void Awake()
    {
        upgradeButton.onClick.AddListener(OnUpgrade);
        Init(_upgradeConfig);
    }
    protected abstract void Init(UpgradeConfig upgradeConfig);
    private void OnUpgrade()
    {
        if (_gameScore.GetScore >= _price)
        {
            _gameScore.RemoveScore(_price);
            UpgradePower();
            ScalePrice();
        }
    }
    protected abstract void UpgradePower();
    private void ScalePrice()
    {
        _price = (int)(_price * _scale);
        _count++;
        textCountUpgrade.text = string.Format("x{0}", _count);
        textUpgradePrice.text = string.Format("Price: {0}", _price);
    }
}
