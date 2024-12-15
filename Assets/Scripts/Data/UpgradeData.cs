using UnityEngine;
[System.Serializable]
public struct UpgradeData
{
    [SerializeField] string name;
    [SerializeField] int startPrice;
    [SerializeField] int revealScore;
    [SerializeField] int upgrade;
    [SerializeField] float scale;

    public string Name { get => name; }
    public int StartPrice { get => startPrice; }
    public int RevealScore { get => revealScore; }
    public int Upgrade { get => upgrade; }
    public float Scale { get => scale; }
}
