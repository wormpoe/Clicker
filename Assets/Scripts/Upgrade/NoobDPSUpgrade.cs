using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class NoobDPSUpgrade : MonoBehaviour, IUpgradeble
{
    private int _upgradePrice = 50;
    private int _countUpgrade = 0;
    private float _scalePrice = 2.5f;
    private int _dpsUpgrade = 1;
    private GameScore _gameScore;
    private DamageOverTimePower _dpsPower;
    [SerializeField] Button upgradeButton;
    [SerializeField] TextMeshProUGUI textUpgradePrice;
    [SerializeField] TextMeshProUGUI textCountUpgrade;

    [Inject]
    private void Construct(GameScore gameScore, DamageOverTimePower dpsPower)
    {
        _gameScore = gameScore;
        _dpsPower = dpsPower;
    }
    private void Awake()
    {
        upgradeButton.onClick.AddListener(Upgrade);
    }
    public void Upgrade()
    {
        if (_gameScore.Score >= _upgradePrice)
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
        textUpgradePrice.text = string.Format("Price{0}", _upgradePrice);
    }
}
