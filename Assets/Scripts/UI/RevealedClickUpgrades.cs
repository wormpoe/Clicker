using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class RevealedClickUpgrades : MonoBehaviour, IRevealed
{
    private SignalBus _signalBus;
    private UpgradeConfig _upgradeConfig;
    private List<ClickUpgradeData> _clickUpgradeDatas;
    private int _clickId;
    [SerializeField] List<GameObject> revealedClickItems;

    [Inject]
    private void Construct(SignalBus signalBus, UpgradeConfig upgradeConfig)
    {
        _signalBus = signalBus;
        _upgradeConfig = upgradeConfig;
    }
    private void Awake()
    {
        _clickUpgradeDatas = _upgradeConfig.ClickUpgradeDatas;
        _signalBus.Subscribe<ScoreCangedSignal>(OnRevealed);
        foreach (var reveal in revealedClickItems)
        {
            reveal.SetActive(false);
        }
        _clickId = 0;
    }
    public void OnRevealed(ScoreCangedSignal signal)
    {
        if (signal.Value >= _clickUpgradeDatas[_clickId].StartPrice)
        {
            revealedClickItems[_clickId].SetActive(true);
            if (_clickId < _clickUpgradeDatas.Count - 1)
            {
                _clickId++;
            }
        }
    }
}
