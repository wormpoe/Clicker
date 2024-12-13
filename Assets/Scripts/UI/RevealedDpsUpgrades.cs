using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class RevealedDpsUpgrades : MonoBehaviour, IRevealed
{
    private SignalBus _signalBus;
    private UpgradeConfig _upgradeConfig;
    private List<DpsUpgradeData> _dpsUpgradeDatas;
    private int _dpsId;
    [SerializeField] List<GameObject> revealedDpsItems;

    [Inject]
    private void Construct(SignalBus signalBus, UpgradeConfig upgradeConfig)
    {
        _signalBus = signalBus;
        _upgradeConfig = upgradeConfig;
    }
    private void Awake()
    {
        _dpsUpgradeDatas = _upgradeConfig.DpsUpgradeDatas;
        _signalBus.Subscribe<ScoreCangedSignal>(OnRevealed);
        foreach (var reveal in revealedDpsItems)
        {
            reveal.SetActive(false);
        }
        _dpsId = 0;
    }
    public void OnRevealed(ScoreCangedSignal signal)
    {
        if (signal.Value >= _dpsUpgradeDatas[_dpsId].StartPrice)
        {
            revealedDpsItems[_dpsId].SetActive(true);
            if (_dpsId < _dpsUpgradeDatas.Count - 1)
            {
                _dpsId++;
            }
        }
    }
}
