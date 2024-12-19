using UnityEngine;
[System.Serializable]
public struct UpgradeData
{
    [SerializeField] string name;
    [SerializeField] float startPrice;
    [SerializeField] int startExponent;
    [SerializeField] float revealScore;
    [SerializeField] float upgrade;
    [SerializeField] float scale;

    public string Name { get => name; }
    public float StartPrice { get => startPrice; }
    public int StartExponent { get => startExponent; }
    public float RevealScore { get => revealScore; }
    public float Upgrade { get => upgrade; }
    public float Scale { get => scale; }
}
