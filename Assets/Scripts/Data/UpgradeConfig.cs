using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "UpgradeConfig", menuName = "ScriptableObjects/UpgradeConfig", order = 1)]
public class UpgradeConfig : ScriptableObject
{ 
    [SerializeField] List<UpgradeData> clickUpgradeData;
    [SerializeField] List<UpgradeData> dpsUpgradeData;
    [SerializeField] List<RevealShopData> revealShopDatas;

    public List<UpgradeData> ClickUpgradeData { get => clickUpgradeData; }
    public List<UpgradeData> DpsUpgradeData { get => dpsUpgradeData; }
    public List<RevealShopData> RevealShopDatas { get => revealShopDatas; }
}
