using UnityEngine;

public class ClickController : IClickable
{
    public int Click(int score, int value) {
        Debug.Log(score + value);
        return score + value;
    }
    public bool Check(ClickableUnit unit) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == unit.gameObject;
    }
}
