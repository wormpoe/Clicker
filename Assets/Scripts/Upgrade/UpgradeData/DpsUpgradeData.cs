using UnityEngine;
[System.Serializable]
public struct DpsUpgradeData
{
    [SerializeField] string name;
    [SerializeField] int startPrice;
    [SerializeField] int dpsUpgrade;
    [SerializeField] float scale;

    public int StartPrice { get => startPrice; }
    public int DpsUpgrade { get => dpsUpgrade; }
    public float Scale { get => scale; }
}
