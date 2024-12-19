using UnityEngine;
using Zenject;

public class GameScore
{
    private float _score = 0f;
    private int _exponent = 0;
    private SignalBus _signalBus;
    private CalculateLargeNumbers _calculateLargeNumbers;
    public float GetScore { get => _score; }
    public int GetExponent { get => _exponent; }

    [Inject]
    private void Construct(SignalBus signalBus, CalculateLargeNumbers calculateLargeNumbers)
    {
        _signalBus = signalBus;
        _calculateLargeNumbers = calculateLargeNumbers;
    }
    public void AddScore(float score, int exponent)
    {
        _score = _score + score / Mathf.Pow(10, _exponent - exponent);
        var result = _calculateLargeNumbers.Calculate(_score);
        _score = result.Item1;
        _exponent += result.Item2;
        if (_exponent == 0)
        {
            _score = Mathf.Floor(_score);
        }
        _signalBus.Fire(new ScoreCangedSignal(_score, _exponent));
    }
    public void RemoveScore(float score, int exponent)
    {
        if (_score - score == 0)
        {
            _score = 0f;
            _exponent = 0;
            _signalBus.Fire(new ScoreCangedSignal(_score, _exponent));
            return;
        }
        _score = _score - score / Mathf.Pow(10, _exponent - exponent);
        var result = _calculateLargeNumbers.Calculate(_score);
        _score = result.Item1;
        _exponent += result.Item2;
        if (_exponent == 0)
        {
            _score = Mathf.Floor(_score);
        }
        _signalBus.Fire(new ScoreCangedSignal(_score, _exponent));
    }
}
