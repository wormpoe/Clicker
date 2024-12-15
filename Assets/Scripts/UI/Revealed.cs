using UnityEngine;
using Zenject;
using System.Collections.Generic;
using System.Linq;

public abstract class Revealed : MonoBehaviour
{
    private SignalBus _signalBus;
    private UpgradeConfig _upgradeConfig;
    protected List<UpgradeData> _upgradeData;
    [SerializeField] protected List<RevealedItem> revealedItems;

    [Inject]
    private void Construct(SignalBus signalBus, UpgradeConfig upgradeConfig)
    {
        _signalBus = signalBus;
        _upgradeConfig = upgradeConfig;
    }
    private void Awake()
    {
         Init(_upgradeConfig);
        _signalBus.Subscribe<ScoreCangedSignal>(OnRevealed);
        foreach (var reveal in revealedItems)
        {
            reveal.Item.SetActive(false);
        }
    }
    protected abstract void Init(UpgradeConfig upgradeConfig);
    private void OnRevealed(ScoreCangedSignal signal)
    {
        var objectRevealed = _upgradeData
            .Join(revealedItems,
            _clickUpgradeDatas => _clickUpgradeDatas.Name,
            revealedClickItems => revealedClickItems.Name,
            (_clickUpgradeDatas, revealedClickItems) => new
            {
                RevealedObject = revealedClickItems.Item,
                RevealedScore = _clickUpgradeDatas.RevealScore
            }
            )
            .Where(match => signal.Value >= match.RevealedScore)
            .Select(reveal => reveal.RevealedObject);

        foreach (var reveal in objectRevealed)
        {
            reveal.SetActive(true);
        }
    }

}
