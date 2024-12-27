using UnityEngine;
using DG.Tweening;

public class ShopAnimation : MonoBehaviour
{
    [SerializeField] GameObject _shop;
    public void OpenAnimation()
    {
        _shop.SetActive(true);
        _shop.transform.DOMoveX(150f, 0.2f);
    }
    public void CloseAnimation()
    {
        _shop.transform.DOMoveX(-150f, 0.2f).OnComplete(() => _shop.SetActive(false));
    }
}
