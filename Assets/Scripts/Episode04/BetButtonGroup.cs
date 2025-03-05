using Pbm;
using System.Collections.Generic;
using UnityEngine;

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

    public BetButton CheckButton { get { return _checkButton; } set { _checkButton = value; } }
    public BetButton AnteButton { get { return _anteButton; } set { _anteButton = value; } }
    public BetButton CallButton { get { return _callButton; } set { _callButton = value; } }
    public BetButton HalfButton { get { return _halfButton; } set { _halfButton = value; } }
    public BetButton FullButton { get { return _fullButton; } set { _fullButton = value; } }
    public BetButton AllinButton { get { return _allinButton; } set { _allinButton = value; } }
    public BetButton FoldButton { get { return _foldButton; } set { _foldButton = value; } }

    private List<BetButton> _betButtons = new();

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

        foreach (var betButton in _betButtons)
        {
            betButton.Initialize();
            betButton.Disable();
        }
    }

    private void OnEnable()
    {
        GameManager.Event.OnResEnableBet += Event_OnResEnableBet;
    }

    private void OnDisable()
    {
        GameManager.Event.OnResEnableBet -= Event_OnResEnableBet;
    }

    private void Event_OnResEnableBet(object sender, ResEnableBet e)
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
                    break;
                case Pbm.Bet.Bbing:
                    _anteButton.SetButton(bet.Bet, bet.Chips, bet.Enable, this);
                    break;
                case Pbm.Bet.Half:
                    _halfButton.SetButton(bet.Bet, bet.Chips, bet.Enable, this);
                    break;
                case Pbm.Bet.Full:
                    _fullButton.SetButton(bet.Bet, bet.Chips, bet.Enable, this);
                    break;
                case Pbm.Bet.Allin:
                    _allinButton.SetButton(bet.Bet, bet.Chips, bet.Enable, this);
                    break;
                case Pbm.Bet.Fold:
                    _foldButton.SetButton(bet.Bet, bet.Chips, bet.Enable, this);
                    break;
                case Pbm.Bet.Call:
                    _callButton.SetButton(bet.Bet, bet.Chips, bet.Enable, this);
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
    }
}
