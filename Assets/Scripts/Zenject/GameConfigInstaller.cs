using Zenject;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameConfigInstaller", menuName = "Installers/GameConfigInstaller")]
public class GameConfigInstaller : ScriptableObjectInstaller<GameConfigInstaller>
{
    [SerializeField] UpgradeConfig upgradeConfig;
    public override void InstallBindings()
    {
        Container.Bind<UpgradeConfig>().FromInstance(upgradeConfig);
    }
}
