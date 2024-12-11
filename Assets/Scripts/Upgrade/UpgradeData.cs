using UnityEngine;
[System.Serializable]
public struct UpgradeData
{
    [Header("NoobClickUpgrade")]
    [SerializeField] int clickNoobStartPirce;
    [SerializeField] float clickNoobScalePrice;
    [SerializeField] int clickNoobScalePower;
    [Header("RegularClickUpgrade")]
    [SerializeField] int clickRegularStartPirce;
    [SerializeField] float clickRegularScalePrice;
    [SerializeField] int clickRegularScalePower;
    [Header("NoobDPSUpgrade")]
    [SerializeField] int dpsNoobStartPirce;
    [SerializeField] float dpsNoobScalePrice;
    [SerializeField] int dpsNoobScalePower;

    public int ClickNoobStartPrice { get => clickNoobStartPirce; }
    public float ClickNoobScalePrice { get => clickNoobScalePrice; }
    public int ClickNoobScalePower { get => clickNoobScalePower; }
    public int ClickRegularStartPrice { get => clickRegularStartPirce; }
    public float ClickRegularScalePrice { get => clickRegularScalePrice; }
    public int ClickRegularScalePower { get => clickRegularScalePower; }
    public int DpsNoobStartPrice { get => dpsNoobStartPirce; }
    public float DpsNoobScalePrice { get => dpsNoobScalePrice; }
    public int DpsNooobScalePower { get => dpsNoobScalePower; }
}
