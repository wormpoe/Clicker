using DG.Tweening;
using UnityEngine;
using Zenject;

public class RevealedShopInterface : MonoBehaviour
{
    [SerializeField] private GameObject _openShopButton;
    [SerializeField] private GameObject _dpsTab;
    [SerializeField] private GameObject _clickTab;

    private bool _shopButtonIsRevealed;
    private bool _dpsAndClickTabIsRevealed;
    private GameScore _gameScore;

    [Inject]
    private void Construct(GameScore gameScore, SignalBus scoreChangeSignal)
    {
        _gameScore = gameScore;
        scoreChangeSignal.Subscribe<ScoreCangedSignal>(Reveal);
    }

    private void Awake()
    {
        _openShopButton.SetActive(false);
        _dpsTab.SetActive(false);
        _clickTab.SetActive(false);
        _shopButtonIsRevealed = false;
        _dpsAndClickTabIsRevealed= false;
    }
    private void Reveal()
    {
        RevealShopButton();
        RevealDpsAndClickTab();
    }
    private void RevealShopButton()
    {
        if (_gameScore.GetScore >= 10 && !_shopButtonIsRevealed)
        {
            _shopButtonIsRevealed = true;
            _openShopButton.SetActive(true);
            RevealedAnimation(_openShopButton.transform);
        }
    }
    private void RevealDpsAndClickTab()
    {
        if (_gameScore.GetScore >= 50 && !_dpsAndClickTabIsRevealed)
        {
            _dpsAndClickTabIsRevealed = true;
            _clickTab.SetActive(true);
            _dpsTab.SetActive(true);
            RevealedAnimation(_clickTab.transform);
            RevealedAnimation(_dpsTab.transform);
        }
    }
    private void RevealedAnimation(Transform transform)
    {
        transform.localScale = Vector3.zero;
        Sequence revealAnimation = DOTween.Sequence();
        revealAnimation
            .Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.2f))
            .Append(transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.2f))
            .Append(transform.DOScale(Vector3.one, 0.3f));
    }
}
