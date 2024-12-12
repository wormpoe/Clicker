using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "UpgradeConfig", menuName = "ScriptableObjects/UpgradeConfig", order = 1)]
public class UpgradeConfig : ScriptableObject
{ 
    [SerializeField] List<ClickUpgradeData> clickUpgradeData;
    [SerializeField] List<DpsUpgradeData> dpsUpgradeData;

    public List<ClickUpgradeData> ClickUpgradeData { get => clickUpgradeData; }
    public List<DpsUpgradeData> DpsUpgradeData { get => dpsUpgradeData; }
}
