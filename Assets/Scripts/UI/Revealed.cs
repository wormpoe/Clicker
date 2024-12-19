using UnityEngine;
using Zenject;
using System.Collections.Generic;
using System.Linq;

public abstract class Revealed : MonoBehaviour
{
    private SignalBus _signalBus;
    private UpgradeConfig _upgradeConfig;
    private GameScore _gameScore;
    protected List<UpgradeData> _upgradeData;
    [SerializeField] protected List<RevealedItem> revealedItems;

    [Inject]
    private void Construct(SignalBus signalBus, UpgradeConfig upgradeConfig, GameScore gameScore)
    {
        _signalBus = signalBus;
        _upgradeConfig = upgradeConfig;
        _gameScore = gameScore;
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
    private void OnEnable()
    {
        OnRevealed(null);
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
            .Where(match => _gameScore.GetScore >= match.RevealedScore)
            .Select(reveal => reveal.RevealedObject);

        foreach (var reveal in objectRevealed)
        {
            reveal.SetActive(true);
        }
    }

}
