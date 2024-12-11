using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeConfig", menuName = "ScriptableObjects/UpgradeConfig", order = 1)]
public class UpgradeConfig : ScriptableObject
{
    [SerializeField] UpgradeData _upgradeData;

    public UpgradeData UpgradeData { get => _upgradeData; }
}
