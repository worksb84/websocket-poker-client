using Pbm;
using UnityEngine;
using UnityEngine.Events;

public class Episode04 : MonoBehaviour
{
    private static Episode04 _instance;

    public static Episode04 Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj;
                obj = GameObject.Find(typeof(Episode04).Name);
                if (obj == null)
                {
                    obj = new GameObject(typeof(Episode04).Name);
                    _instance = obj.AddComponent<Episode04>();
                }
                else
                {
                    _instance = obj.GetComponent<Episode04>();
                }
            }
            return _instance;
        }
    }

    [Header("Groups")]
    [SerializeField] private TopGroup _topGroup;
    [SerializeField] private BetButtonGroup _betButtonGroup;
    [SerializeField] private HiLoButtonGroup _hiLoButtonGroup;
    [SerializeField] private SeatGroup _seatGroup;
    [SerializeField] private AmountGroup _amountGroup;
    [SerializeField] private ChoiceGroup _choiceGroup;
    [SerializeField] private ShuffleGroup _shuffleGroup;

    void Start()
    {
        _topGroup.gameObject.SetActive(true);
        _betButtonGroup.gameObject.SetActive(true);
        _hiLoButtonGroup.gameObject.SetActive(false);
        _seatGroup.gameObject.SetActive(true);
        _amountGroup.gameObject.SetActive(true);
        _choiceGroup.gameObject.SetActive(false);

        _shuffleGroup.StartShuffle();
        //_seatGroup.Deal(3);
    }

    private void Event_OnResTimer(object sender, ResTimer e)
    {
        Debug.Log("Event_OnResTimer");
        Debug.Log(e);
    }

    private void Event_OnResStreetBoss(object sender, ResStreetBoss e)
    {
        Debug.Log("Event_OnResStreetBoss");
        Debug.Log(e);
        _seatGroup.StreetBoss(e);
    }

    private void Event_OnResStartStreet(object sender, ResStartStreet e)
    {
        Debug.Log("Event_OnResStartStreet");
        Debug.Log(e);
    }

    private void Event_OnResResult(object sender, ResResult e)
    {
        Debug.Log("Event_OnResResult");
        Debug.Log(e);
    }

    private void Event_OnResReady(object sender, ResReady e)
    {
        Debug.Log("Event_OnResReady");
        Debug.Log(e);
    }

    private void Event_OnResOtherPlayers(object sender, ResOtherPlayers e)
    {
        Debug.Log("Event_OnResOtherPlayers");
        Debug.Log(e);
    }

    private void Event_OnResMoveRoom(object sender, ResMoveRoom e)
    {
        Debug.Log("Event_OnResMoveRoom");
        Debug.Log(e);
    }

    private void Event_OnResLeave(object sender, ResLeave e)
    {
        Debug.Log("Event_OnResLeave");
        Debug.Log(e);
    }

    private void Event_OnResJoinPlayer(object sender, ResJoinPlayer e)
    {
        Debug.Log("Event_OnResJoinPlayer");
        Debug.Log(e);
    }



    private void Event_OnResDealCard(object sender, ResDealCard e)
    {
        Debug.Log("Event_OnResDealCard");
        Debug.Log(e);
    }

    private void Event_OnResBullBear(object sender, ResBullBear e)
    {
        Debug.Log("Event_OnResBullBear");
        Debug.Log(e);
    }

    private void Event_OnResBet(object sender, ResBet e)
    {
        Debug.Log("Event_OnResBet");
        Debug.Log(e);
        _seatGroup.Bet(e);
    }

    private void OnEnable()
    {
        GameManager.Event.OnResBet += Event_OnResBet;
        GameManager.Event.OnResBullBear += Event_OnResBullBear;
        GameManager.Event.OnResBullBearReady += Event_OnResBullBearReady;
        GameManager.Event.OnResDealCard += Event_OnResDealCard;
        GameManager.Event.OnResDealStreet3Card += Event_OnResDealStreet3Card;
        GameManager.Event.OnResGameStart += Event_OnResGameStart;
        GameManager.Event.OnResJoinPlayer += Event_OnResJoinPlayer;
        GameManager.Event.OnResLeave += Event_OnResLeave;
        GameManager.Event.OnResMoveRoom += Event_OnResMoveRoom;
        GameManager.Event.OnResOtherPlayers += Event_OnResOtherPlayers;
        GameManager.Event.OnResReady += Event_OnResReady;
        GameManager.Event.OnResResult += Event_OnResResult;
        GameManager.Event.OnResSelectOpenCard += Event_OnResSelectOpenCard;
        GameManager.Event.OnResShuffleCard += Event_OnResShuffleCard;
        GameManager.Event.OnResStartStreet += Event_OnResStartStreet;
        GameManager.Event.OnResStreetBoss += Event_OnResStreetBoss;
        GameManager.Event.OnResTimer += Event_OnResTimer;
    }

    private void OnDisable()
    {
        GameManager.Event.OnResBet -= Event_OnResBet;
        GameManager.Event.OnResBullBear -= Event_OnResBullBear;
        GameManager.Event.OnResBullBearReady -= Event_OnResBullBearReady;
        GameManager.Event.OnResDealCard -= Event_OnResDealCard;
        GameManager.Event.OnResDealStreet3Card -= Event_OnResDealStreet3Card;
        GameManager.Event.OnResGameStart -= Event_OnResGameStart;
        GameManager.Event.OnResJoinPlayer -= Event_OnResJoinPlayer;
        GameManager.Event.OnResLeave -= Event_OnResLeave;
        GameManager.Event.OnResMoveRoom -= Event_OnResMoveRoom;
        GameManager.Event.OnResOtherPlayers -= Event_OnResOtherPlayers;
        GameManager.Event.OnResReady -= Event_OnResReady;
        GameManager.Event.OnResResult -= Event_OnResResult;
        GameManager.Event.OnResSelectOpenCard -= Event_OnResSelectOpenCard;
        GameManager.Event.OnResShuffleCard -= Event_OnResShuffleCard;
        GameManager.Event.OnResStartStreet -= Event_OnResStartStreet;
        GameManager.Event.OnResStreetBoss -= Event_OnResStreetBoss;
        GameManager.Event.OnResTimer -= Event_OnResTimer;
    }


    private void Event_OnResBullBearReady(object sender, ResBullBearReady e)
    {
        Debug.Log("Event_OnResBullBearReady");
        Debug.Log(e);
        _betButtonGroup.gameObject.SetActive(false);
        _hiLoButtonGroup.gameObject.SetActive(true);
    }

    private void Event_OnResDealStreet3Card(object sender, ResDealStreet3Card e)
    {
        Debug.Log("Event_OnResDealStreet3Card");
        Debug.Log(e);

        UnityAction action = (() =>
        {
            _choiceGroup.gameObject.SetActive(true);
        });

        StartCoroutine(_seatGroup.DealStreet3Card(e, action));
        _choiceGroup.SetCards(e);
    }

    private void Event_OnResSelectOpenCard(object sender, ResSelectOpenCard e)
    {
        Debug.Log("Event_OnResSelectOpenCard");
        Debug.Log(e);

        _seatGroup.SelectOpenCard(e);
    }

    private void Event_OnResGameStart(object sender, ResGameStart e)
    {
        Debug.Log("Event_OnResGameStart");
        Debug.Log(e);
        _shuffleGroup.gameObject.SetActive(false);
    }

    private void Event_OnResShuffleCard(object sender, ResShuffleCard e)
    {
        Debug.Log("Event_OnResShuffleCard");
        Debug.Log(e);
        _shuffleGroup.gameObject.SetActive(true);
    }
}
