using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MultiplieUpgrade : MonoBehaviour
{
    private SignalBus _signalBus;
    [SerializeField] Button upgradeX1;
    [SerializeField] Button upgradeX10;
    [SerializeField] Button upgradeX50;
    [SerializeField] Button upgradeMax;

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    private void Awake()
    {
        upgradeX1.onClick.AddListener(() => MultiplieCount(1));
        upgradeX10.onClick.AddListener(() => MultiplieCount(10));
        upgradeX50.onClick.AddListener(() => MultiplieCount(50));
        upgradeMax.onClick.AddListener(() => MultiplieCount(0));
    }
    private void MultiplieCount(int count)
    {
        _signalBus.Fire(new CountUpgradeSignal(count));
        _signalBus.Fire(new ChangePriceSignal());
    }
}
