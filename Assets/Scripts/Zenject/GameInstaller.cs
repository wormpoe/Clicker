using System.Diagnostics.Contracts;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameScore>().AsSingle();
    }
}
