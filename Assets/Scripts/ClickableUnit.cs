using UnityEngine;
using Zenject;
public class ClickableUnit : MonoBehaviour
{
    private int _clickValue = 1;
    private int _points = 0;
    private IClickable _clickController;

    [Inject]
    public void Construct(IClickable clickController) {
        _clickController = clickController;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && _clickController.Check(this)) {
            _points = _clickController.Click(_points, _clickValue);
        }
    }
}