using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using System;

public abstract class ButtonUpgrade : MonoBehaviour
{
    [SerializeField] private float _priceMantissa;
    [SerializeField] private NumberName _priceExponentName;
    [SerializeField] private float _priceScale;
    [SerializeField] private TextMeshProUGUI _textUpgradePrice;
    [SerializeField] private TextMeshProUGUI _textCountUpgrade;
    [SerializeField] protected float _powerUpgradeMantissa;
    [SerializeField] private NumberName _powerUpgradeExponentName;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] protected string _upgradeName;

    private GameScore _gameScore;
    private CalculateCount _calculateCount;
    private CalculatePrice _calculatePrice;
    private Revealed _revealed;
    private SignalBus _signalBus;
    private int _countUpgrade;
    protected int _tempCount;
    private float _tempMantissa;
    private int _tempExponent;
    private int _priceExponent;
    protected int _powerUpgradeExponent;

    [Inject]
    protected void Construct(GameScore gameScore, CalculatePrice calculatePrice, CalculateCount calculateCount, SignalBus signalBus, Revealed revealed)
    {
        _gameScore = gameScore;
        _calculatePrice = calculatePrice;
        _calculateCount = calculateCount;
        _signalBus = signalBus;
        _revealed = revealed;
    }
    private void Awake()
    {
        _signalBus.Subscribe<ChangePriceSignal>(UpdatePrice);
        _signalBus.Subscribe<ScoreCangedSignal>(UpdatePrice);
        _upgradeButton.onClick.AddListener(OnUpgrade);
        _priceExponent = (int)_priceExponentName;
        _powerUpgradeExponent = (int)_powerUpgradeExponentName;
        _tempMantissa = _priceMantissa;
        _tempExponent = _priceExponent;
        _tempCount = 1;
        _upgradeButton.interactable = false;
        _revealed.Init(_upgradeName, _priceMantissa, _priceExponent, gameObject);
    }
    private void OnEnable()
    {
        GetPrice();
    }
    private void Update()
    {
        if (_gameScore.GetScore >= _tempMantissa / Mathf.Pow(10, _gameScore.GetExponent - _tempExponent) && _upgradeButton.interactable == false)
        {
            _upgradeButton.interactable = !_upgradeButton.interactable;
        }
        if (_gameScore.GetScore < _tempMantissa / Mathf.Pow(10, _gameScore.GetExponent - _tempExponent) && _upgradeButton.interactable == true)
        {
            _upgradeButton.interactable = !_upgradeButton.interactable;
        }
    }
    private void OnUpgrade()
    {
        if (_gameScore.GetScore >= _tempMantissa / Mathf.Pow(10, _gameScore.GetExponent - _tempExponent))
        {
            _countUpgrade += _tempCount;
            SendPower();
            GetCount();
            var newPrice = _calculatePrice.CalculateNewPrice(_priceMantissa, _priceExponent, _priceScale, _tempCount);
            _priceMantissa = newPrice.Item1;
            _priceExponent += newPrice.Item2;
            _gameScore.RemoveScore(_tempMantissa, _tempExponent);
        }
    }
    protected abstract void SendPower();
    private void UpdatePrice()
    {
        _tempCount = _calculateCount.Calculate(_priceMantissa, _priceScale, _priceExponent, _tempCount);
        var tempPrice = _calculatePrice.CalculateTempPrice(_priceMantissa, _priceExponent, _priceScale, _tempCount);
        _tempMantissa = tempPrice.Item1;
        _tempExponent = tempPrice.Item2;
        GetPrice();
    }
    private void GetPrice()
    {
        _textUpgradePrice.text = string.Format("Price x{0}: {1}{2}", _tempCount, MathF.Round(_tempMantissa, 1), (_tempExponent > 0) ? Enum.GetName(typeof(NumberName), _tempExponent) : "");
    }
    private void GetCount()
    {
        _textCountUpgrade.text = string.Format("x{0}", _countUpgrade);
    }
}
