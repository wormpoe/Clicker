using UnityEngine;
using Zenject;
using DG.Tweening;

public class ClickableUnit : MonoBehaviour
{
    private GameScore _gameScore;
    private ClickPower _clickPower;
    private DamageOverTimePower _dpsPower;
    private Camera _mainCamera;
    private SignalBus _signalBus;
    private float _tickInterval = 1;
    private float _timer = 0;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    [Inject]
    private void Construct(GameScore gameScore, ClickPower clickPower, DamageOverTimePower dpsPower, SignalBus signalBus)
    {
        _gameScore = gameScore;
        _clickPower = clickPower;
        _dpsPower = dpsPower;
        _signalBus = signalBus;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject)
            {
                ClickAnimation();
                GetScore(_clickPower, Input.mousePosition);
            }
        }
        _timer += Time.deltaTime;
        if (_timer >= _tickInterval)
        {
            _timer -= _tickInterval;
            GetScore(_dpsPower, _dpsPower.GenerationRandomPosition(transform, _mainCamera));
        }
    }
    private void GetScore(IPower power, Vector3 position)
    {
        if (power == null || power.GetPower() == 0f)
            return;
        _gameScore.AddScore(power.GetPower(), power.GetExponent());
        _signalBus.Fire(new SpawnPositionSignal(position, power.GetPower(), power.GetExponent()));
    }
    private void ClickAnimation()
    {
        Vector3 vec = new Vector3(0.1f, 0.1f, 0.3f);
        transform.localScale = Vector3.one;
        transform.DOKill();
        transform.DOShakeScale(0.2f, vec, 15, 20);
    }
}
