using UnityEngine;
using Zenject;

public class GameScore
{
    private int score = 0;
    public int Score { get => score; }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log(score);
    }
    public void RemoveScore(int value)
    {
        score -= value;
        Debug.Log(score);
    }
}
