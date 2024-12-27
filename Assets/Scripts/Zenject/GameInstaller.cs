using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSignal();
        BindSelectType();
        Container.Bind<GameScore>().AsSingle();
        Container.Bind<CalculatePrice>().AsSingle();
        Container.Bind<CalculateCount>().AsSingle();
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
    private void BindSelectType()
    {
        Container.Bind<Power>().WithId(TypeName.ClickPower).To<ClickPower>().AsSingle();
        Container.Bind<Power>().WithId(TypeName.DpsPower).To<DpsPower>().AsSingle();
        Container.Bind<TypeFactory>().AsSingle();
    }
}
