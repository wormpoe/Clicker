using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "UpgradeConfig", menuName = "ScriptableObjects/UpgradeConfig", order = 1)]
public class UpgradeConfig : ScriptableObject
{ 
    [SerializeField] List<ClickUpgradeData> clickUpgradeDatas;
    [SerializeField] List<DpsUpgradeData> dpsUpgradeDatas;
    [SerializeField] List<RevealShopData> revealShopDatas;

    public List<ClickUpgradeData> ClickUpgradeDatas { get => clickUpgradeDatas; }
    public List<DpsUpgradeData> DpsUpgradeDatas { get => dpsUpgradeDatas; }
    public List<RevealShopData> RevealShopDatas { get => revealShopDatas; }
}
