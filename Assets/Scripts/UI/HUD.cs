using UnityEngine;
using TMPro;
using Zenject;
using System;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI clickPower;
    [SerializeField] TextMeshProUGUI dpsPower;
    private string lolkek;
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
        score.text = string.Format("Score: {0}{1}", MathF.Round(signal._mantissa, 1), (signal._exponent > 0) ? Enum.GetName(typeof(NumberName), signal._exponent) : "");
    }
    private void OnPowerClickCanged(ClickPowerSignal signal)
    {
        clickPower.text = string.Format("Click power: {0}{1}", MathF.Round(signal.Click, 1), (signal.Exponent > 0) ? Enum.GetName(typeof(NumberName), signal.Exponent) : "");
    }
    private void OnPowerDPSChanged(DPSPowerSignal signal)
    {
        dpsPower.text = string.Format("DPS power: {0}{1}", MathF.Round(signal.DamagePerSecond, 1), (signal.Exponent > 0) ? Enum.GetName(typeof(NumberName), signal.Exponent) : "");
    }
}
