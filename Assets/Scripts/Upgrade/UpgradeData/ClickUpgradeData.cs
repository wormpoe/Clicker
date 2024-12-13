using UnityEngine;
[System.Serializable]
public struct ClickUpgradeData
{
    [SerializeField] string name;
    [SerializeField] int startPrice;
    [SerializeField] int clickUpgrade;
    [SerializeField] float scale;

    public int StartPrice { get => startPrice; }
    public int ClickUpgrade { get => clickUpgrade; }
    public float Scale { get => scale; }
}
