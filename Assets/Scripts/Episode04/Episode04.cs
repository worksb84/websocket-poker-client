using Pbm;
using System;
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
    [Header("Player Properties")]
    [SerializeField] private int _uid = -1;
    [SerializeField] private Pbm.Seat _seat = new();

    public int Uid { get { return Instance._uid; } set { Instance._uid = value; } }
    public Pbm.Seat Seat { get { return Instance._seat; } set { Instance._seat = value; } }

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



    private void Event_OnResBullBear(object sender, ResBullBear e)
    {
        Debug.Log("Event_OnResBullBear");
        Debug.Log(e);
    }

    private void OnEnable()
    {
        GameManager.Event.OnResBullBear += Event_OnResBullBear;
        GameManager.Event.OnResBullBearReady += Event_OnResBullBearReady;
        GameManager.Event.OnResDealCard += Event_OnResDealCard;
        GameManager.Event.OnResDealStreet3Card += Event_OnResDealStreet3Card;
        GameManager.Event.OnResGameStart += Event_OnResGameStart;
        GameManager.Event.OnResJoinPlayer += Event_OnResJoinPlayer;
        GameManager.Event.OnResRegistPlayer += Event_OnResRegistPlayer;
        GameManager.Event.OnResLeave += Event_OnResLeave;
        GameManager.Event.OnResMoveRoom += Event_OnResMoveRoom;
        GameManager.Event.OnResOtherPlayers += Event_OnResOtherPlayers;
        GameManager.Event.OnResReady += Event_OnResReady;
        GameManager.Event.OnResResult += Event_OnResResult;
        GameManager.Event.OnResSelectOpenCard += Event_OnResSelectOpenCard;
        GameManager.Event.OnResShuffleCard += Event_OnResShuffleCard;
        GameManager.Event.OnResStartStreet += Event_OnResStartStreet;
        GameManager.Event.OnResChoiceCard += Event_OnResChoiceCard;
    }

    private void OnDisable()
    {
        GameManager.Event.OnResBullBear -= Event_OnResBullBear;
        GameManager.Event.OnResBullBearReady -= Event_OnResBullBearReady;
        GameManager.Event.OnResDealCard -= Event_OnResDealCard;
        GameManager.Event.OnResDealStreet3Card -= Event_OnResDealStreet3Card;
        GameManager.Event.OnResGameStart -= Event_OnResGameStart;
        GameManager.Event.OnResJoinPlayer -= Event_OnResJoinPlayer;
        GameManager.Event.OnResRegistPlayer -= Event_OnResRegistPlayer;
        GameManager.Event.OnResLeave -= Event_OnResLeave;
        GameManager.Event.OnResMoveRoom -= Event_OnResMoveRoom;
        GameManager.Event.OnResOtherPlayers -= Event_OnResOtherPlayers;
        GameManager.Event.OnResReady -= Event_OnResReady;
        GameManager.Event.OnResResult -= Event_OnResResult;
        GameManager.Event.OnResSelectOpenCard -= Event_OnResSelectOpenCard;
        GameManager.Event.OnResShuffleCard -= Event_OnResShuffleCard;
        GameManager.Event.OnResStartStreet -= Event_OnResStartStreet;
        GameManager.Event.OnResChoiceCard -= Event_OnResChoiceCard;
    }

    private void Event_OnResChoiceCard(object sender, ResChoiceCard e)
    {
        var isSelf = _seatGroup.SetChoice(e);
        if(isSelf)
        {
            _choiceGroup.gameObject.SetActive(false);
        }
    }

    private void Event_OnResRegistPlayer(object sender, ResRegistPlayer e)
    {
        _seatGroup.SetSeat(e.Player, true);
    }

    private void Event_OnResBullBearReady(object sender, ResBullBearReady e)
    {
        _betButtonGroup.gameObject.SetActive(false);
        _hiLoButtonGroup.gameObject.SetActive(true);
    }

    private void Event_OnResDealStreet3Card(object sender, ResDealStreet3Card e)
    {
        UnityAction action = (() =>
        {
            _choiceGroup.gameObject.SetActive(true);
        });

        StartCoroutine(_seatGroup.SetStreet3Card(e, action));
        _choiceGroup.SetCards(e);
    }

    private void Event_OnResSelectOpenCard(object sender, ResSelectOpenCard e)
    {
        _seatGroup.SetOpenCard(e);
        _choiceGroup.gameObject.SetActive(false);
    }

    private void Event_OnResGameStart(object sender, ResGameStart e)
    {
        _shuffleGroup.gameObject.SetActive(false);
    }

    private void Event_OnResShuffleCard(object sender, ResShuffleCard e)
    {
        _shuffleGroup.gameObject.SetActive(true);
    }


    private void Event_OnResDealCard(object sender, ResDealCard e)
    {
        StartCoroutine(_seatGroup.SetDealCard(e));
    }

    private void Event_OnResJoinPlayer(object sender, ResJoinPlayer e)
    {
        _seatGroup.SetPlayer(e);
    }
    private void Event_OnResOtherPlayers(object sender, ResOtherPlayers e)
    {
        _seatGroup.SetOtherPlayers(e);
    }
}
