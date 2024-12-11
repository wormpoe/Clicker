using UnityEngine;
using TMPro;
using Zenject;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI clickPower;
    [SerializeField] TextMeshProUGUI dpsPower;
    private SignalBus _signalBus;

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    private void Awake()
    {
        _signalBus.Subscribe<ScoreCangedSignal>(OnScoreCanged);
        _signalBus.Subscribe<ClickPowerSignal>(OnPowerClickCanged);
        _signalBus.Subscribe<DPSPowerSignal>(OnPowerDPSChanged);
    }
    private void OnScoreCanged(ScoreCangedSignal signal)
    {
        score.text = string.Format("Score: {0}", signal.Value);
    }
    private void OnPowerClickCanged(ClickPowerSignal signal)
    {
        clickPower.text = string.Format("Click power: {0}", signal.Value);
    }
    private void OnPowerDPSChanged(DPSPowerSignal signal)
    {
        dpsPower.text = string.Format("DPS power: {0}", signal.Value);
    }
}
