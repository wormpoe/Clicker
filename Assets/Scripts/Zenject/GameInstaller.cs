using System.Diagnostics.Contracts;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSignal();
        Container.Bind<GameScore>().AsSingle();
    }

    private void BindSignal()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<ScoreCangedSignal>().OptionalSubscriber();
    }
}
