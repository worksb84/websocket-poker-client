using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetButton : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text _betText;
    [SerializeField] private TMP_Text _betAmount;

    public TMP_Text BetText { get { return _betText; } set { _betText = value; } }
    public TMP_Text BetAmount { get { return _betAmount; } set { _betAmount = value; } }

    internal void Initialize()
    {
        _betAmount.text = string.Empty;
        _betAmount.gameObject.SetActive(false);
    }

    internal void SetButton(Pbm.Bet bet, uint chips, bool enable, BetButtonGroup betButtonGroup)
    {
        var button = gameObject.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        if (enable)
        {
            Enable();
            _betAmount.text = chips.ToString();
            _betAmount.gameObject.SetActive(true);
            button.onClick.AddListener(() => Bet(bet, chips, betButtonGroup));
        }
        else
        {
            Disable();
        }
    }

    private void Enable()
    {
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        gameObject.GetComponent<Button>().enabled = true;
    }

    internal void Disable()
    {
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 50);
        gameObject.GetComponent<Button>().enabled = false;
    }

    private void Bet(Pbm.Bet bet, uint chips, BetButtonGroup betButtonGroup)
    {
        var req = new Pbm.ReqBet() {
            Bet = bet,
            Chips = chips,
            Seat = Episode04.Instance.Seat
        };

        GameManager.Network.Send(req);
        betButtonGroup.Disable();
    }
}
