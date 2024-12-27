using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class Revealed : MonoBehaviour
{
    private SignalBus _signalBus;
    private GameScore _gameScore;
    [SerializeField] private List<RevealedItem> revealedItems;

    [Inject]
    private void Construct(SignalBus signalBus, GameScore gameScore)
    {
        _signalBus = signalBus;
        _gameScore = gameScore;
    }
    private void Awake()
    {
        _signalBus.Subscribe<ScoreCangedSignal>(OnRevealed);
        foreach (var reveal in revealedItems)
        {
            reveal.Init();
        }
    }
    private void OnRevealed(ScoreCangedSignal signal)
    {
        foreach (var revealItem in revealedItems)
        {
            revealItem.Revealed(_gameScore.GetScore, _gameScore.GetExponent);
        }
    }
}
