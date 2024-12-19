using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class RevealedShop : MonoBehaviour
{
    private SignalBus _signalBus;
    private UpgradeConfig _upgradeConfig;
    private List<RevealShopData> _revealShopDatas;
    private int _revealId;
    private GameScore _gameScore;
    [SerializeField] List<GameObject> revealedShopObjects;
    [SerializeField] GameObject shop;

    [Inject]
    private void Construct(SignalBus signalBus, UpgradeConfig upgradeConfig, GameScore gameScore)
    {
        _signalBus = signalBus;
        _upgradeConfig = upgradeConfig;
        _gameScore = gameScore;
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
    private void OnEnable()
    {
        OnRevealed(null);
    }
    public void OnRevealed(ScoreCangedSignal signal)
    {
        if (_gameScore.GetScore >= _revealShopDatas[_revealId].RevealValue)
        {
            revealedShopObjects[_revealId].SetActive(true);
            if(_revealId < revealedShopObjects.Count - 1)
            {
                _revealId++;
            }
        }
    }
}
