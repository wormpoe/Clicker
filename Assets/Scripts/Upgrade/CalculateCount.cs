using UnityEngine;
using Zenject;

public class CalculateCount
{
    private int _count = 1;
    private GameScore _gameScore;
    [Inject]
    private void Construct(SignalBus signalBus, GameScore gameScore)
    {
        signalBus.Subscribe<CountUpgradeSignal>(OnCount);
        _gameScore = gameScore;
    }
    private void OnCount(CountUpgradeSignal signal)
    {
        _count = signal.Value;
    }
    public int Calculate(float price, float scale, int exponent, int localCount)
    {
        if (_count == 0)
        {
            float ratio = (_gameScore.GetScore * (1 - scale)) / (price / Mathf.Pow(10, _gameScore.GetExponent - exponent));
            localCount = (int)Mathf.Floor(Mathf.Log(1 - ratio) / Mathf.Log(scale));
            if (localCount == 0)
                localCount = 1;
            return localCount;
        }
        else
        {
            return _count;
        }
    }
}
