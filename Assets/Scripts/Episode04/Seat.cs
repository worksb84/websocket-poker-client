using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Seat : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private bool _isSelf = false;
    [SerializeField] private Pbm.Seat _seat;

    [Header("Images")]
    [SerializeField] private Image _profileImage;
    [SerializeField] private Image _bossImage;

    [Header("Texts")]
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _rateText;
    [SerializeField] private TMP_Text _previousBetAmount;
    [SerializeField] private TMP_Text _resultText;
    [SerializeField] private TMP_Text _resultAmount;
    [SerializeField] private TMP_Text _waitPlayerText;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _moneyText;

    [Header("GameObjects")]
    [SerializeField] private GameObject _cardGroup;
    [SerializeField] private GameObject _timerGroup;
    [SerializeField] private GameObject _resultGroup;
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _dealCardGroup;
    [SerializeField] private GameObject _turn;
    [SerializeField] private GameObject _moneyGroup;

    [Header("Betting GameObjects")]
    [SerializeField] private GameObject _check;
    [SerializeField] private GameObject _ante;
    [SerializeField] private GameObject _call;
    [SerializeField] private GameObject _half;
    [SerializeField] private GameObject _full;
    [SerializeField] private GameObject _allin;
    [SerializeField] private GameObject _fold;

    public bool IsSelf { get { return _isSelf; } set { _isSelf = value; } }
    public Pbm.Seat Seat_ { get { return _seat; } set { _seat = value; } }
    public Image ProfileImage { get { return _profileImage; } set { _profileImage = value; } }
    public TMP_Text NameText { get { return _nameText; } set { _nameText = value; } }
    public TMP_Text RateText { get { return _rateText; } set { _rateText = value; } }
    public TMP_Text PreviousBetAmount { get { return _previousBetAmount; } set { _previousBetAmount = value; } }
    public Image BossImage { get { return _bossImage; } set { _bossImage = value; } }
    public TMP_Text ResultText { get { return _resultText; } set { _resultText = value; } }
    public TMP_Text ResultAmount { get { return _resultAmount; } set { _resultAmount = value; } }
    public TMP_Text WaitPlayerText { get { return _waitPlayerText; } set { _waitPlayerText = value; } }
    public TMP_Text MoneyText { get { return _moneyText; } set { _moneyText = value; } }
    public GameObject CardGroup { get { return _cardGroup; } set { _cardGroup = value; } }
    public GameObject TimerGroup { get { return _timerGroup; } set { _timerGroup = value; } }
    public GameObject ResultGroup { get { return _resultGroup; } set { _resultGroup = value; } }
    public GameObject MoneyGroup { get { return _moneyGroup; } set { _moneyGroup = value; } }
    public Slider Slider { get { return _slider; } set { _slider = value; } }
    public TMP_Text TimerText { get { return _timerText; } set { _timerText = value; } }
    public GameObject DealCardGroup { get { return _dealCardGroup; } set { _dealCardGroup = value; } }
    public GameObject Turn { get { return _turn; } set { _turn = value; } }
    private GameObject Check { get { return _check; } set { _check = value; } }
    private GameObject Ante { get { return _ante; } set { _ante = value; } }
    private GameObject Call { get { return _call; } set { _call = value; } }
    private GameObject Half { get { return _half; } set { _half = value; } }
    private GameObject Full { get { return _full; } set { _full = value; } }
    private GameObject Allin { get { return _allin; } set { _allin = value; } }
    private GameObject Fold { get { return _fold; } set { _fold = value; } }

    private int _dealCardCount = 0;
    private List<GameObject> _dealCards = new();
    private Dictionary<Pbm.Bet, GameObject> _bets = new();

    private void OnEnable()
    {
        GameManager.Event.OnResTimer += Event_OnResTimer;
    }

    private void OnDisable()
    {
        GameManager.Event.OnResTimer -= Event_OnResTimer;
    }

    private void Start()
    {
        //StartTimer();
        Initialize();
    }

    private void Initialize()
    {
        _seat = new Pbm.Seat() { Seat_ = -1, Uid = -1, Rate = 0 };
        _bets.Clear();

        _bets.Add(Pbm.Bet.Check, _check);
        _bets.Add(Pbm.Bet.Bbing, _ante);
        _bets.Add(Pbm.Bet.Call, _call);
        _bets.Add(Pbm.Bet.Half, _half);
        _bets.Add(Pbm.Bet.Full, _full);
        _bets.Add(Pbm.Bet.Allin, _allin);
        _bets.Add(Pbm.Bet.Fold, _fold);

        ResetBet();
        _turn.SetActive(false);

        _dealCards.Clear();
        _dealCardCount = 0;
        _profileImage.sprite = null;
        _nameText.text = string.Empty;
        _rateText.text = string.Empty;
        _previousBetAmount.text = string.Empty;

        _profileImage.gameObject.SetActive(false);
        _bossImage.gameObject.SetActive(false);
        _nameText.gameObject.SetActive(false);
        _rateText.gameObject.SetActive(false);

        for (int i = 0; i < _cardGroup.transform.childCount; i++)
        {
            Destroy(_cardGroup.transform.GetChild(i).gameObject);
        }
        _timerGroup.SetActive(false);
        _resultGroup.SetActive(false);
    }

    private void Event_OnResTimer(object sender, Pbm.ResTimer e)
    {
        if (e.Seat.Seat_ == _seat.Seat_)
        {
            if (e.Time == 5)
            {
                StartTimer();
            }
            if (e.Time <= 0)
            {
                StopTimer();
            }
            if (e.Time <= 5)
            {
                _timerText.gameObject.SetActive(true);
                _timerText.text = e.Time.ToString();
            }
        }
    }

    private void StartTimer()
    {
        _timerGroup.SetActive(true);
        _timerText.gameObject.SetActive(false);
        _slider.value = 0f;
        _slider.DOValue(1f, 1f).SetEase(Ease.Linear).SetLoops(-1);
    }

    private void StopTimer()
    {
        _timerGroup.SetActive(false);
        _timerText.gameObject.SetActive(false);
        _slider.DOKill();
    }

    internal void SetSort()
    {
        foreach (var card in _dealCards)
        {
            var cardRect = card.GetComponent<RectTransform>();
            cardRect.DORotate(Vector3.zero, 0.2f);
        }
    }

    internal void SetOpenCard(Pbm.SelectOpenCard selectOpenCard)
    {
        if (_isSelf)
        {
            var idx = _dealCards.FindIndex(x => { return x.GetComponent<PlayCard>().Card_.S == selectOpenCard.Card.S; });
            var temp = _dealCards[2].GetComponent<PlayCard>();
            var tempPropertie = temp.Card_;
            var open = _dealCards[idx].GetComponent<PlayCard>();
            var openPropertie = open.Card_;
            temp.SetCard(openPropertie);
            open.SetCard(tempPropertie);

            foreach (var dealCard in _dealCards)
            {
                dealCard.GetComponent<PlayCard>().SetFlip(true);
            }
        }
        else
        {
            var dealCard = _dealCards[2].GetComponent<PlayCard>();
            dealCard.SetCard(selectOpenCard.Card);
            dealCard.SetFlip(true);
        }
    }

    internal void SetCard(Pbm.ResDealStreet3Card e)
    {
        for (int i = 0; i < e.Cards.Count; i++)
        {
            var dealCard = _dealCards[i].GetComponent<PlayCard>();
            dealCard.SetCard(e.Cards[i]);
        }
    }

    private void ResetBet()
    {
        foreach (var (_, bet) in _bets)
        {
            bet.SetActive(false);
        }
    }

    internal void SetBet(Pbm.ResBet e)
    {
        ResetBet();
        var icon = _bets[e.Bet];
        icon.SetActive(true);
        //_betImage.gameObject.SetActive(true);
        _previousBetAmount.text = e.Chips.ToString();
        StopTimer();
    }

    internal void SetStreetBoss()
    {
        _bossImage.gameObject.SetActive(true);
    }

    internal void ResetStreetBoss()
    {
        _bossImage.gameObject.SetActive(false);
    }

    internal void SetSeat(Pbm.Player player, bool isSelf)
    {
        _seat = player.Seat;
        _isSelf = isSelf;
        _profileImage.gameObject.SetActive(true);
        _nameText.gameObject.SetActive(true);
        _nameText.text = player.Name;
        _waitPlayerText.gameObject.SetActive(false);
    }

    internal IEnumerator SetDealCard(float waitForSeconds)
    {
        yield return new WaitForSeconds(0.01f);
        var rect = _cardGroup.GetComponent<RectTransform>();
        var root = gameObject.transform.root.root.GetComponent<RectTransform>();

        var bound = RectTransformUtility.CalculateRelativeRectTransformBounds(root, rect);
        var cX = bound.center.x - bound.extents.x;
        var cY = bound.center.y;

        var card = GameManager.Resource.Instantiate("Prefabs/PlayCard");
        card.transform.SetParent(_dealCardGroup.transform, false);
        _dealCards.Add(card);

        var gap = _isSelf ? 75f : 46.67f;
        var scale = _isSelf ? 1f : 0.6365f;

        var cardRect = card.GetComponent<RectTransform>();
        cardRect.anchorMin = Vector2.one * 0.5f;
        cardRect.anchorMax = Vector2.one * 0.5f;
        cardRect.pivot = new Vector2(0, 0.5f);
        cardRect.localScale = Vector3.one * scale;
        cardRect.anchoredPosition = new Vector2(0, 800f);

        var seq = DOTween.Sequence();
        seq.Append(cardRect.DOAnchorPos(new Vector2(cX + (_dealCardCount * gap), cY), waitForSeconds));
        seq.Join(cardRect.DORotate(new Vector3(0f, 0f, Random.Range(-4f, 4f)), waitForSeconds));
        seq.Play();

        _dealCardCount++;
    }

    internal void SetOpenDealCard(Pbm.DealCard dealCard)
    {
        //var idx = _dealCards.FindIndex(x => x.GetComponent<PlayCard>().Card_ != null && x.GetComponent<PlayCard>().Card_.S == dealCard.Card.S)
        var card = _dealCards[_dealCards.Count - 1];
        var playCard = card.GetComponent<PlayCard>();
        playCard.SetCard(dealCard.Card);
        playCard.SetFlip(true);
    }

    internal void ChoiceComplate()
    {
        StopTimer();
    }
}
