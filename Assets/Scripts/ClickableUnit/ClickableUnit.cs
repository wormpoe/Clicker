using UnityEngine;
using Zenject;
using DG.Tweening;
using System.Collections;

public class ClickableUnit : MonoBehaviour
{
    private GameScore _gameScore;
    private ClickPower _clickPower;
    private DpsPower _dpsPower;
    private Camera _mainCamera;
    private SignalBus _signalBus;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    [Inject]
    private void Construct(GameScore gameScore, ClickPower clickPower, DpsPower dpsPower, SignalBus signalBus)
    {
        _gameScore = gameScore;
        _signalBus = signalBus;
        _clickPower = clickPower;
        _dpsPower = dpsPower;
    }
    void Update()
    {
        ClickRegistrate();
        DpsRegistrate();
    }
    private void ClickRegistrate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject)
            {
                ClickAnimation();
                GetScore(_clickPower);
            }
        }
    }
    private void DpsRegistrate()
    {
        if (_dpsPower is DpsPower dpsPower)
        {
            foreach (var item in dpsPower.DpsItem.Values)
            {
                if (item.PowerMantissa > 0 && item.IsRunning == false)
                    StartCoroutine(TickDps(dpsPower, item));
            }
        }
    }
    private void GetScore(Power power)
    {
        _signalBus.Fire(new SpawnPositionSignal(Input.mousePosition, power.GetPower(), power.GetExponent()));
        _gameScore.AddScore(power.GetPower(), power.GetExponent());
    }
    private void ClickAnimation()
    {
        Vector3 vec = new Vector3(0.1f, 0.1f, 0.3f);
        transform.localScale = Vector3.one;
        transform.DOKill();
        transform.DOShakeScale(0.2f, vec, 15, 20);
    }
    IEnumerator TickDps(DpsPower dpsPower, DpsItem item)
    {
        item.ControlTicking();
        yield return new WaitForSeconds(item.TickInterval);
        Vector3 animationPosition;
        animationPosition = dpsPower.GenerationRandomPosition(transform, _mainCamera);
        _gameScore.AddScore(item.PowerMantissa, item.PowerExponent);
        _signalBus.Fire(new SpawnPositionSignal(animationPosition, item.PowerMantissa, item.PowerExponent));
        item.ControlTicking();
    }
}
