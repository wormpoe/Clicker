using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class Revealed
{
    private GameScore _gameScore;
    private Dictionary<string, RevealedItem> _revealedItems = new Dictionary<string, RevealedItem>();

    [Inject]
    private void Construct(GameScore gameScore, SignalBus signalBus)
    {
        _gameScore = gameScore;
        signalBus.Subscribe<ScoreCangedSignal>(OnRevealed);
    }

    private void OnRevealed(ScoreCangedSignal signal)
    {
        foreach (var revealItem in _revealedItems)
        {
            revealItem.Value.Revealed(_gameScore.GetScore, _gameScore.GetExponent);
        }
    }
    public void Init(string name, float mantissa, int exponent, GameObject revealObject)
    {
        if (!_revealedItems.ContainsKey(name))
        {
            var newItem = new RevealedItem();
            newItem.Init(mantissa, exponent, revealObject);
            _revealedItems[name] = newItem;
        }
    }
}
