using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using System.Collections;

public abstract class Upgrade : MonoBehaviour
{
    protected int _price;
    protected float _scale;
    protected int _upgrade;
    protected int _count;
    protected int _tpmPrice;
    protected int _tmpCount;
    private bool _isRunning;
    private bool _isMaxUgrader;
    private SignalBus _signalBus;
    private GameScore _gameScore;
    private UpgradeConfig _upgradeConfig;
    [SerializeField] protected Button upgradeButton;
    [SerializeField] protected TextMeshProUGUI textUpgradePrice;
    [SerializeField] protected TextMeshProUGUI textCountUpgrade;

    [Inject]
    private void Construct(GameScore gameScore, UpgradeConfig upgradeConfig, SignalBus signalBus)
    {
        _gameScore = gameScore;
        _upgradeConfig = upgradeConfig;
        _signalBus = signalBus;
    }

    private void Awake()
    {
        _signalBus.Subscribe<CountUpgradeSignal>(OnCount);
        upgradeButton.onClick.AddListener(OnUpgrade);
        Init(_upgradeConfig);
        _isMaxUgrader = false;
        _isRunning = false;
        _tmpCount = 1;
        _count = 0;
    }
    private void OnCount(CountUpgradeSignal signal)
    {
        _tmpCount = signal.Value;
        _isMaxUgrader = signal.Value == 0;
        if (!_isRunning && _isMaxUgrader)
        {
            StartCoroutine(MaxUpgrade());
        }
        ScalePrice();
    }
    private void OnDisable()
    {
        _isRunning = false;
        if(MaxUpgrade() != null)
        {
            StopCoroutine(MaxUpgrade());
        }
    }
    protected abstract void Init(UpgradeConfig upgradeConfig);
    private void OnUpgrade()
    {
        if (_gameScore.GetScore >= _tpmPrice)
        {
            _gameScore.RemoveScore(_tpmPrice);
            UpgradePower();
            _count += _tmpCount;
            textCountUpgrade.text = string.Format("x{0}", _count);
            _price = (int)Mathf.Floor(_price * Mathf.Pow(_scale, _tmpCount));
            ScalePrice();
        }
    }
    protected abstract void UpgradePower();
    private void ScalePrice()
    {
        _tpmPrice = (int)Mathf.Floor(_price * (1 - Mathf.Pow(_scale, _tmpCount)) / (1 - _scale));
        textUpgradePrice.text = string.Format("Price x{0}: {1}",_tmpCount, _tpmPrice);
    }
    private IEnumerator MaxUpgrade()
    {
        _isRunning = true;
        while (_isMaxUgrader)
        {
            float ratio = (_gameScore.GetScore * (1 - _scale)) / _price;
            _tmpCount = (int)Mathf.Floor(Mathf.Log(1 - ratio) / Mathf.Log(_scale));
            if (_tmpCount == 0) 
                _tmpCount = 1;
            ScalePrice();
            yield return null;
        }
        _isRunning = false;
    }
}
