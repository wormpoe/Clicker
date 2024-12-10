using UnityEngine;
using Zenject;

public class GameScore
{
    private int _score = 0;
    private SignalBus _signalBus;
    public int Score { get => _score; }

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    public void AddScore(int value)
    {
        _score += value;
        _signalBus.Fire(new ScoreCangedSignal(_score));
    }
    public void RemoveScore(int value)
    {
        _score -= value;
        _signalBus.Fire(new ScoreCangedSignal(_score));
    }
}
