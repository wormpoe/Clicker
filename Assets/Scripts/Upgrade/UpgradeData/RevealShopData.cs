using UnityEngine;
[System.Serializable]
public struct RevealShopData
{
    [SerializeField] string name;
    [SerializeField] int revealValue;

    public int RevealValue { get => revealValue; }
}
