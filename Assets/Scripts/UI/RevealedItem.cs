using UnityEngine;
using DG.Tweening;

public class RevealedItem
{
    private GameObject _item;
    private float _revealedMantissa;
    private int _revealedExponent;
    private bool _isRevealed;
    public void Init(float mantissa, int exponent, GameObject revealObject)
    {
        _revealedMantissa = mantissa;
        _revealedExponent = exponent;
        _item = revealObject;
        _item.SetActive(false);
        _isRevealed = false;
    }
    public void Revealed(float mantissa, int exponent)
    {
        if (!_isRevealed && ((_revealedMantissa <= mantissa && _revealedExponent == exponent) || _revealedExponent < exponent))
        {
            _isRevealed = true;
            _item.SetActive(true);
            _item.transform.localScale = Vector3.zero;
            Sequence revealAnimation = DOTween.Sequence();
            revealAnimation
                .Append(_item.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.2f))
                .Append(_item.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.2f))
                .Append(_item.transform.DOScale(Vector3.one, 0.3f));
        }
    }
}
