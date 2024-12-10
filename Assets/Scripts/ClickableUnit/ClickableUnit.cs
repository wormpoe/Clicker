using UnityEngine;
using Zenject;

public class ClickableUnit : MonoBehaviour
{
    private int _click = 1;
    private GameScore _gameScore;
    [Inject]
    private void Construct(GameScore gameScore)
    {
        _gameScore = gameScore;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject)
            {
                _gameScore.AddScore(_click);
            }
        }
    }
    public void ClickUpdate(int value)
    {
        _click += value;
    }
}
