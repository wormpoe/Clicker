using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class NoobUpgrade : MonoBehaviour, IUpgradeble
{
    private int _upgradePrice = 10;
    private int _countUpgrade = 0;
    private float _scalePrice = 1.5f;
    private int _clickUpgrade = 1;
    private GameScore _gameScore;
    private ClickPower _clickPower;
    [SerializeField] Button upgradeButton;
    [SerializeField] TextMeshProUGUI textUpgradePrice;
    [SerializeField] TextMeshProUGUI textCountUpgrade;

    [Inject]
    private void Construct(GameScore gameScore, ClickPower clickPower)
    {
        _gameScore = gameScore;
        _clickPower = clickPower;
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
            _clickPower.ClickUpdate(_clickUpgrade);
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
