using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using System.Collections;
using System;

public abstract class Upgrade : MonoBehaviour
{
    protected float _price;
    protected int _exponent;
    protected float _scale;
    protected float _upgrade;
    protected int _count;
    protected float _tmpPrice;
    protected int _tmpExponent;
    protected int _tmpCount;
    private bool _isRunning;
    private SignalBus _signalBus;
    protected GameScore _gameScore;
    private UpgradeConfig _upgradeConfig;
    private CountHolder _countUpgrade;
    private CalculateLargeNumbers _calculateLargeNumbers;
    [SerializeField] protected Button upgradeButton;
    [SerializeField] protected TextMeshProUGUI textUpgradePrice;
    [SerializeField] protected TextMeshProUGUI textCountUpgrade;

    [Inject]
    private void Construct(GameScore gameScore, UpgradeConfig upgradeConfig, SignalBus signalBus, CountHolder count, CalculateLargeNumbers calculateLargeNumbers)
    {
        _gameScore = gameScore;
        _upgradeConfig = upgradeConfig;
        _signalBus = signalBus;
        _countUpgrade = count;
        _calculateLargeNumbers = calculateLargeNumbers;
    }

    private void Awake()
    {
        _signalBus.Subscribe<ChangePriceSignal>(OnChangePrice);
        upgradeButton.onClick.AddListener(OnUpgrade);
        Init(_upgradeConfig);
        _isRunning = false;
        _count = 0;
    }
    private void OnEnable()
    {
        OnChangePrice();
    }
    private void OnChangePrice()
    {
        if (!_isRunning && _countUpgrade.Count == 0 && gameObject.activeInHierarchy)
        {
            StartCoroutine(MaxUpgrade());
            return;
        }
        _tmpCount = _countUpgrade.Count;
        ScalePrice();
    }
    protected abstract void Init(UpgradeConfig upgradeConfig);
    private void OnUpgrade()
    {
        if (_gameScore.GetScore >= _tmpPrice / Mathf.Pow(10, _gameScore.GetExponent - _tmpExponent))
        {
            _gameScore.RemoveScore(_tmpPrice, _tmpExponent);
            ApproveUpgrade();
            ScalePrice();
            UpgradePower();
        }
    }
    private void OnDisable()
    {
        _isRunning = false;
        StopCoroutine(MaxUpgrade());
    }
    protected abstract void UpgradePower();
    private void ApproveUpgrade()
    {
        _count += _tmpCount;
        textCountUpgrade.text = string.Format("x{0}", _count);
        if (_exponent > 0)
        {
            _price = _price * Mathf.Pow(_scale, _tmpCount);
        }
        else
        {
            _price = Mathf.Floor(_price * Mathf.Pow(_scale, _tmpCount));
        }
        var newPrice = _calculateLargeNumbers.Calculate(_price);
        _price = newPrice.Item1;
        _exponent += newPrice.Item2;
    }
    private void ScalePrice()
    {
        var newPrice = _calculateLargeNumbers.Calculate(_price);
        _tmpExponent = newPrice.Item2 + _exponent;
        if (_tmpExponent > 0)
        {
            _tmpPrice = newPrice.Item1 * (1 - Mathf.Pow(_scale, _tmpCount)) / (1 - _scale);
        }
        else
        {
            _tmpPrice = Mathf.Floor(newPrice.Item1 * (1 - Mathf.Pow(_scale, _tmpCount)) / (1 - _scale));
        }
        newPrice = _calculateLargeNumbers.Calculate(_tmpPrice);
        _tmpPrice = newPrice.Item1;
        _tmpExponent += newPrice.Item2;
        textUpgradePrice.text = string.Format("Price x{0}: {1}{2}",_tmpCount, MathF.Round(_tmpPrice, 1), Enum.GetName(typeof(NumberName), _tmpExponent));
    }
    private IEnumerator MaxUpgrade()
    {
        _isRunning = true;
        while (_countUpgrade.Count == 0)
        {
            float ratio = (_gameScore.GetScore * (1 - _scale)) / (_price/Mathf.Pow(10, _gameScore.GetExponent - _exponent));
            _tmpCount = (int)Mathf.Floor(Mathf.Log(1 - ratio) / Mathf.Log(_scale));
            if (_tmpCount == 0) 
                _tmpCount = 1;
            ScalePrice();
            yield return null;
        }
        _isRunning = false;
    }
}
