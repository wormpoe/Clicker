using UnityEngine;
using Zenject;

public class ClickableUnit : MonoBehaviour
{
    private int click = 1;
    private GameScore _gameScore;
    [Inject]
    public void Construct(GameScore gameScore)
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
                _gameScore.AddScore(click);
            }
        }
    }
    public void ClickUpdate(int value)
    {
        click += value;
    }
}
