using Zenject;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfigInstaller", menuName = "Installers/GameConfigInstaller")]
public class GameConfigInstaller : ScriptableObjectInstaller<GameConfigInstaller>
{
    [SerializeField] UpgradeConfig upgradeConfig;
    public override void InstallBindings()
    {
        Container.Bind<UpgradeData>().FromInstance(upgradeConfig.UpgradeData);
    }
}
