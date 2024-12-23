using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MultiplieUpgrade : MonoBehaviour
{
    private SignalBus _signalBus;
    private List<Button> upgrades;
    private int _upgradeCount;
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
        _upgradeCount = 1;
        upgradeX1.onClick.AddListener(() => MultiplieCount(1));
        upgradeX10.onClick.AddListener(() => MultiplieCount(10));
        upgradeX50.onClick.AddListener(() => MultiplieCount(50));
        upgradeMax.onClick.AddListener(() => MultiplieCount(0));
        upgrades = new List<Button>{upgradeX1, upgradeX10, upgradeX50, upgradeMax};
    }
    private void OnEnable()
    {
        ChangeButtonColor(ChoiceButton(), Color.green);
    }
    private void MultiplieCount(int count)
    {
        _upgradeCount = count;
        foreach (var button in upgrades)
        {
            ChangeButtonColor(button, Color.white);
        }
        ChangeButtonColor(ChoiceButton(), Color.green);
        _signalBus.Fire(new CountUpgradeSignal(_upgradeCount));
        _signalBus.Fire(new ChangePriceSignal());
    }
    private void ChangeButtonColor(Button button, Color color)
    {
        var buttonColor = button.colors;
        buttonColor.normalColor = color;
        buttonColor.selectedColor = color;
        if (buttonColor.normalColor == Color.green)
        {
            buttonColor.highlightedColor = color;
        }
        else
        {
            buttonColor.highlightedColor = Color.white;
        }
        button.colors = buttonColor;
    }
    private Button ChoiceButton()
    {
        switch (_upgradeCount)
        {
            case 0:
                return upgradeMax;
            case 1:
                return upgradeX1;
            case 10:
                return upgradeX10;
            case 50:
                return upgradeX50;
            default:
                return upgradeX1;
        }
    }
}
