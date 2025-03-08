using TMPro;
using UnityEngine;

public class AmountGroup : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text _totalAmount;
    [SerializeField] private TMP_Text _callAmount;

    private uint _total = 0;

    public TMP_Text TotalAmount { get { return _totalAmount; } set { _totalAmount = value; } }
    public TMP_Text CallAmount { get { return _callAmount; } set { _callAmount = value; } }


    private void OnEnable()
    {
        GameManager.Event.OnResTableInformation += Event_OnResTableInformation;
        GameManager.Event.OnResEnableBet += Event_OnResEnableBet;
        GameManager.Event.OnResBet += Event_OnResBet;
    }
    private void OnDisable()
    {
        GameManager.Event.OnResTableInformation -= Event_OnResTableInformation;
        GameManager.Event.OnResEnableBet -= Event_OnResEnableBet;
        GameManager.Event.OnResBet -= Event_OnResBet;
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _total = 0;
        _totalAmount.text = "0";
        _callAmount.text = "0";
    }

    private void Event_OnResEnableBet(object sender, Pbm.ResEnableBet e)
    {
        foreach (var bet in e.EnableBet)
        {
            if (bet.Bet == Pbm.Bet.Call)
            {
                _callAmount.text = bet.Chips.ToString();
                break;
            }
        }
    }

    private void Event_OnResBet(object sender, Pbm.ResBet e)
    {
        _total += e.Chips;
        _totalAmount.text = _total.ToString();
    }


    private void Event_OnResTableInformation(object sender, Pbm.ResTableInformation e)
    {
        SetTableInformation(e);
    }


    private void SetTableInformation(Pbm.ResTableInformation e)
    {
        _total = e.Total;
        _totalAmount.text = e.Total.ToString();
    }
}
