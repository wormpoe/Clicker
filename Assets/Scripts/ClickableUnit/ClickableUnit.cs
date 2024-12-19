using UnityEngine;
using Zenject;

public class ClickableUnit : MonoBehaviour
{
    private GameScore _gameScore;
    private ClickPower _clickPower;
    private DamageOverTimePower _dpsPower;
    private Camera _mainCamera;
    private float _tickInterval = 1;
    private float _timer = 0;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    [Inject]
    private void Construct(GameScore gameScore, ClickPower clickPower, DamageOverTimePower dpsPower)
    {
        _gameScore = gameScore;
        _clickPower = clickPower;
        _dpsPower = dpsPower;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject)
            {
                GetScore(_clickPower);
            }
        }
        _timer += Time.deltaTime;
        if (_timer >= _tickInterval)
        {
            _timer -= _tickInterval;
            GetScore(_dpsPower);
        }
    }
    private void GetScore(IPower power)
    {
        if (power == null || power.GetPower() == 0f)
            return;
        _gameScore.AddScore(power.GetPower(), power.GetExponent());
    }
}
