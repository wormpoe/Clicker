using UnityEngine;
using Zenject;

public class RevealedShop : MonoBehaviour
{
    private SignalBus _signalBus;
    private UpgradeData _upgradeData;
    [SerializeField] GameObject shopButton;
    [SerializeField] GameObject clickShopButton;
    [SerializeField] GameObject dpsShopButton;
    [SerializeField] GameObject clickRegularUpgrade;
    [SerializeField] GameObject shop;

    [Inject]
    private void Construct(SignalBus signalBus, UpgradeData upgradeData)
    {
        _signalBus = signalBus;
        _upgradeData = upgradeData;
    }
    private void Awake()
    {

        _signalBus.Subscribe<ScoreCangedSignal>(OnFirstRevealShop);
        _signalBus.Subscribe<ScoreCangedSignal>(OnRevealDpsTab);
        _signalBus.Subscribe<ScoreCangedSignal>(OnOtherReveal);
        shopButton.SetActive(false);
        clickShopButton.SetActive(false);
        dpsShopButton.SetActive(false);
        clickRegularUpgrade.SetActive(false);
        shop.SetActive(false);
    }
    private void OnFirstRevealShop(ScoreCangedSignal signal)
    {
        if (signal.Value < _upgradeData.ClickNoobStartPrice)
            return;
        shopButton.SetActive(true);
    }
    private void OnRevealDpsTab(ScoreCangedSignal signal)
    {
        if (signal.Value < _upgradeData.DpsNoobStartPrice)
            return;
        clickShopButton.SetActive(true);
        dpsShopButton.SetActive(true);
    }
    private void OnOtherReveal(ScoreCangedSignal signal)
    {
        if (signal.Value < _upgradeData.ClickRegularStartPrice)
            return;
        clickRegularUpgrade.SetActive(true);
    }
}
