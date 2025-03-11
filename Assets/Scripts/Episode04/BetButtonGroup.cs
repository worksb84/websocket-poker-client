using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetButtonGroup : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private BetButton _checkButton;
    [SerializeField] private BetButton _anteButton;
    [SerializeField] private BetButton _callButton;
    [SerializeField] private BetButton _halfButton;
    [SerializeField] private BetButton _fullButton;
    [SerializeField] private BetButton _allinButton;
    [SerializeField] private BetButton _foldButton;

    [Header("Images")]
    [SerializeField] private Image _checkButtonText;
    [SerializeField] private Image _anteButtonText;
    [SerializeField] private Image _callButtonText;
    [SerializeField] private Image _halfButtonText;
    [SerializeField] private Image _fullButtonText;
    [SerializeField] private Image _allinButtonText;
    [SerializeField] private Image _foldButtonText;

    public BetButton CheckButton { get { return _checkButton; } set { _checkButton = value; } }
    public BetButton AnteButton { get { return _anteButton; } set { _anteButton = value; } }
    public BetButton CallButton { get { return _callButton; } set { _callButton = value; } }
    public BetButton HalfButton { get { return _halfButton; } set { _halfButton = value; } }
    public BetButton FullButton { get { return _fullButton; } set { _fullButton = value; } }
    public BetButton AllinButton { get { return _allinButton; } set { _allinButton = value; } }
    public BetButton FoldButton { get { return _foldButton; } set { _foldButton = value; } }

    public Image CheckButtonText { get { return _checkButtonText; } set { _checkButtonText = value; } }
    public Image AnteButtonText { get { return _anteButtonText; } set { _anteButtonText = value; } }
    public Image CallButtonText { get { return _callButtonText; } set { _callButtonText = value; } }
    public Image HalfButtonText { get { return _halfButtonText; } set { _halfButtonText = value; } }
    public Image FullButtonText { get { return _fullButtonText; } set { _fullButtonText = value; } }
    public Image AllinButtonText { get { return _allinButtonText; } set { _allinButtonText = value; } }
    public Image FoldButtonText { get { return _foldButtonText; } set { _foldButtonText = value; } }

    private List<BetButton> _betButtons = new();

    private List<Image> _betButtonTexts = new();

    void Start()
    {
        _betButtons.Clear();
        _betButtons.Add(_checkButton);
        _betButtons.Add(_anteButton);
        _betButtons.Add(_callButton);
        _betButtons.Add(_halfButton);
        _betButtons.Add(_fullButton);
        _betButtons.Add(_allinButton);
        _betButtons.Add(_foldButton);

        _betButtonTexts.Clear();
        _betButtonTexts.Add(_checkButtonText);
        _betButtonTexts.Add(_anteButtonText);
        _betButtonTexts.Add(_callButtonText);
        _betButtonTexts.Add(_halfButtonText);
        _betButtonTexts.Add(_fullButtonText);
        _betButtonTexts.Add(_allinButtonText);
        _betButtonTexts.Add(_foldButtonText);

        foreach (var betButton in _betButtons)
        {
            betButton.Initialize();
            betButton.Disable();
        }
        Disable();
    }

    private void OnEnable()
    {
        GameManager.Event.OnResEnableBet += Event_OnResEnableBet;
        GameManager.Event.OnResBet += Event_OnResBet;
    }

    private void Event_OnResBet(object sender, Pbm.ResBet e)
    {
        Disable();
    }

    private void OnDisable()
    {
        GameManager.Event.OnResEnableBet -= Event_OnResEnableBet;
        GameManager.Event.OnResBet -= Event_OnResBet;
    }

    private void Event_OnResEnableBet(object sender, Pbm.ResEnableBet e)
    {
        Enable();
        foreach (var bet in e.EnableBet)
        {
            switch (bet.Bet)
            {
                case Pbm.Bet.Buyin:
                    break;
                case Pbm.Bet.Check:
                    _checkButton.SetButton(bet.Bet, bet.Chips, bet.Enable, this);
                    _checkButtonText.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    break;
                case Pbm.Bet.Bbing:
                    _anteButton.SetButton(bet.Bet, bet.Chips, bet.Enable, this);
                    _anteButtonText.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    break;
                case Pbm.Bet.Half:
                    _halfButton.SetButton(bet.Bet, bet.Chips, bet.Enable, this);
                    _halfButtonText.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    break;
                case Pbm.Bet.Full:
                    _fullButton.SetButton(bet.Bet, bet.Chips, bet.Enable, this);
                    _fullButtonText.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    break;
                case Pbm.Bet.Allin:
                    _allinButton.SetButton(bet.Bet, bet.Chips, bet.Enable, this);
                    _allinButtonText.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    break;
                case Pbm.Bet.Fold:
                    _foldButton.SetButton(bet.Bet, bet.Chips, bet.Enable, this);
                    _foldButtonText.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    break;
                case Pbm.Bet.Call:
                    _callButton.SetButton(bet.Bet, bet.Chips, bet.Enable, this);
                    _callButtonText.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    break;
                default:
                    break;
            }
        }
    }

    private void Enable()
    {
        foreach (var betButton in _betButtons)
        {
            betButton.Initialize();
        }
    }

    internal void Disable()
    {
        foreach (var betButton in _betButtons)
        {
            betButton.Initialize();
            betButton.Disable();
        }
        foreach (var betButtonText in _betButtonTexts)
        {
            betButtonText.GetComponent<Image>().color = new Color32(255, 255, 255, 50);
        }
    }
}
