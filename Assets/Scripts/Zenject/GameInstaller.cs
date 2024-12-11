using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSignal();
        Container.Bind<GameScore>().AsSingle();
        Container.Bind<ClickPower>().AsSingle();
        Container.Bind<DamageOverTimePower>().AsSingle();
    }

    private void BindSignal()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<ScoreCangedSignal>().OptionalSubscriber();
        Container.DeclareSignal<ClickPowerSignal>().OptionalSubscriber();
        Container.DeclareSignal<DPSPowerSignal>().OptionalSubscriber();
        Container.DeclareSignal<RevealSignal>().OptionalSubscriber();
    }
}
