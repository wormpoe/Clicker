using UnityEngine;
using Zenject;

public class ClickableUnit : MonoBehaviour
{
    private GameScore _gameScore;
    private ClickPower _clickPower;
    private DamageOverTimePower _dpsPower;
    private Camera _mainCamera;
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
        GetScore(_dpsPower);
    }
    private void GetScore(IPower power)
    {
        if (power == null) 
            return;
        _gameScore.AddScore(power.GetPower());
    }
}
