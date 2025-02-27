using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _betText;
    [SerializeField] private TMP_Text _betAmount;

    public TMP_Text BetText { get { return _betText; } set { _betText = value; } }
    public TMP_Text BetAmount { get { return _betAmount; } set { _betAmount = value; } }

    internal void SetButton(Pbm.Bet bet, uint chips, bool enable)
    {
        var button = gameObject.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        if (enable)
        {
            Debug.Log(enable);
            _betText.text = chips.ToString();
            button.onClick.AddListener(() => Bet(bet, chips));
        }
        else
        {
            Debug.Log(enable);
        }
    }


    private void Bet(Pbm.Bet bet, uint chips)
    {
        var req = new Pbm.ReqBet() {
            Bet = bet,
            Chips = chips,
            Seat = new Pbm.Seat()
            {
                Seat_ = 1,
                Uid = 1,
            }
        };

        GameManager.Network.Send(req);
    }
}
