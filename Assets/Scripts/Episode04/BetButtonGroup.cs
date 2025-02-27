using UnityEngine;
using UnityEngine.UI;

public class BetButtonGroup : MonoBehaviour
{
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

    void Start()
    {
    }

    public void EnableBet(Pbm.ResEnableBet e)
    {
        foreach (var bet in e.EnableBet)
        {
            switch (bet.Bet)
            {
                case Pbm.Bet.Buyin:
                    break;
                case Pbm.Bet.Check:
                    _checkButton.SetButton(bet.Bet, bet.Chips, bet.Enable);
                    break;
                case Pbm.Bet.Bbing:
                    _anteButton.SetButton(bet.Bet, bet.Chips, bet.Enable);
                    break;
                case Pbm.Bet.Half:
                    _halfButton.SetButton(bet.Bet, bet.Chips, bet.Enable);
                    break;
                case Pbm.Bet.Full:
                    _fullButton.SetButton(bet.Bet, bet.Chips, bet.Enable);
                    break;
                case Pbm.Bet.Allin:
                    _allinButton.SetButton(bet.Bet, bet.Chips, bet.Enable);
                    break;
                case Pbm.Bet.Fold:
                    _foldButton.SetButton(bet.Bet, bet.Chips, bet.Enable);
                    break;
                case Pbm.Bet.Call:
                    _callButton.SetButton(bet.Bet, bet.Chips, bet.Enable);
                    break;
                default:
                    break;
            }
        }
    }
}
