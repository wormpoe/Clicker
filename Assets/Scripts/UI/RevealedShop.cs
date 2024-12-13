using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class RevealedShop : MonoBehaviour, IRevealed
{
    private SignalBus _signalBus;
    private UpgradeConfig _upgradeConfig;
    private List<RevealShopData> _revealShopDatas;
    private int _revealId;
    [SerializeField] List<GameObject> revealedShopObjects;
    [SerializeField] GameObject shop;

    [Inject]
    private void Construct(SignalBus signalBus, UpgradeConfig upgradeConfig)
    {
        _signalBus = signalBus;
        _upgradeConfig = upgradeConfig;
    }
    private void Awake()
    {
        shop.SetActive(false);
        _revealShopDatas = _upgradeConfig.RevealShopDatas;
        _signalBus.Subscribe<ScoreCangedSignal>(OnRevealed);
        foreach (var revealed in revealedShopObjects)
        {
            revealed.SetActive(false);
        }
        _revealId = 0;
    }
    public void OnRevealed(ScoreCangedSignal signal)
    {
        if (signal.Value >= _revealShopDatas[_revealId].RevealValue)
        {
            revealedShopObjects[_revealId].SetActive(true);
            if(_revealId < revealedShopObjects.Count - 1)
            {
                _revealId++;
            }
        }
    }
}
