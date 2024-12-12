using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class RevealedShop : MonoBehaviour
{
    private SignalBus _signalBus;
    private UpgradeConfig _upgradeConfig;
    private List<ClickUpgradeData> _clickUpgradeData;
    private List<DpsUpgradeData> _dpsUpgradeData;
    private int _dpsId;
    private int _clickId;
    private bool isShopReveal;
    private bool isDpsTabReveal;
    [SerializeField] List<GameObject> revealedClickItems;
    [SerializeField] List<GameObject> revealedDpsItems;
    [SerializeField] GameObject shopButton;
    [SerializeField] GameObject clickShopButton;
    [SerializeField] GameObject dpsShopButton;
    [SerializeField] GameObject shop;

    [Inject]
    private void Construct(SignalBus signalBus, UpgradeConfig upgradeConfig)
    {
        _signalBus = signalBus;
        _upgradeConfig = upgradeConfig;
    }
    private void Awake()
    {
        _clickUpgradeData = _upgradeConfig.ClickUpgradeData;
        _dpsUpgradeData = _upgradeConfig.DpsUpgradeData;
        _signalBus.Subscribe<ScoreCangedSignal>(OnRevealed);
        foreach (var reveal in revealedClickItems)
        {
            reveal.SetActive(false);
        }
        foreach (var reveal in revealedDpsItems)
        {
            reveal.SetActive(false);
        }
        _dpsId = 0;
        _clickId = 0;
        isShopReveal = false;
        isDpsTabReveal = false;
        shopButton.SetActive(false);
        clickShopButton.SetActive(false);
        dpsShopButton.SetActive(false);
        shop.SetActive(false);
        Debug.Log($"{_clickUpgradeData.Count}/{_dpsUpgradeData.Count}");


    }
    private void OnRevealed(ScoreCangedSignal signal)
    {
        if (signal.Value >= _clickUpgradeData[_clickId].StartPrice)
        {
            revealedClickItems[_clickId].SetActive(true);
            if (!isShopReveal)
            {
                shopButton.SetActive(true);
                isShopReveal = true;
            }
            if(_clickId < _clickUpgradeData.Count - 1)
            {
                _clickId++;
            }
        }
        if (signal.Value >= _dpsUpgradeData[_dpsId].StartPrice)
        {
            revealedDpsItems[_dpsId].SetActive(true);
            if (!isDpsTabReveal)
            {
                clickShopButton.SetActive(true);
                dpsShopButton.SetActive(true);
                isDpsTabReveal = true;
            }
            if (_dpsId < _dpsUpgradeData.Count - 1)
            {
                _dpsId++;
            }
        }
    }
}
