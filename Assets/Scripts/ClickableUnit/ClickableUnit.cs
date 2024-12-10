using UnityEngine;
using Zenject;

public class ClickableUnit : MonoBehaviour
{
    private GameScore _gameScore;
    private ClickPower _clickPower;
    [Inject]
    private void Construct(GameScore gameScore, ClickPower clickPower)
    {
        _gameScore = gameScore;
        _clickPower = clickPower;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject)
            {
                _gameScore.AddScore(_clickPower.Click);
            }
        }
    }
}
