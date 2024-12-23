using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System;

public class AddScoreAnimation : MonoBehaviour
{
    [SerializeField] GameObject _canvas;
    [SerializeField] Text _text;
    [Inject]
    private SignalBus _signalBus;
    private void Awake()
    {
        _signalBus.Subscribe<SpawnPositionSignal>(ClickAnimation);
    }
    private void ClickAnimation(SpawnPositionSignal signal)
    {
        _text.text = string.Format("+{0}{1}", MathF.Round(signal.ClickPower, 1), Enum.GetName(typeof(NumberName), signal.Exponetn));
        var newItem = Instantiate(_text, signal.Position, Quaternion.identity, _canvas.transform);
        Sequence animation = DOTween.Sequence();
        animation
            .Append(newItem.gameObject.transform.DOMoveY(signal.Position.y + 50f, 1f + Time.deltaTime))
            .Join(newItem.DOFade(0, 1f + Time.deltaTime))
            .OnKill(() => Destroy(newItem.gameObject));
    }
}
