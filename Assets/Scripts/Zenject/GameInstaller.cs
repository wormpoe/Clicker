using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSignal();
        Container.Bind<GameScore>().AsSingle();
        Container.Bind<ClickPower>().AsSingle();
        Container.Bind<DamageOverTimePower>().AsSingle();
        Container.Bind<CountHolder>().AsSingle();
        Container.Bind<CalculateLargeNumbers>().AsSingle();
    }

    private void BindSignal()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<ScoreCangedSignal>().OptionalSubscriber();
        Container.DeclareSignal<ClickPowerSignal>().OptionalSubscriber();
        Container.DeclareSignal<DPSPowerSignal>().OptionalSubscriber();
        Container.DeclareSignal<CountUpgradeSignal>().OptionalSubscriber();
        Container.DeclareSignal<ChangePriceSignal>().OptionalSubscriber();
        Container.DeclareSignal<SpawnPositionSignal>().OptionalSubscriber();
    }
}
