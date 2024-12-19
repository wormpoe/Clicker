using UnityEngine;
[System.Serializable]
public struct RevealShopData
{
    [SerializeField] string name;
    [SerializeField] float revealValue;

    public float RevealValue { get => revealValue; }
}
