using UnityEngine;
using TMPro;
using Zenject;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    private SignalBus _signalBus;

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    private void Awake()
    {
        _signalBus.Subscribe<ScoreCangedSignal>(OnScoreCanged);
    }
    private void OnScoreCanged(ScoreCangedSignal signal)
    {
        score.text = string.Format("Score: {0}", signal.Value);
    }
}
