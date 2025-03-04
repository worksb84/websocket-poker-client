using System.Collections;
using DG.Tweening;
using Pbm;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Seat : MonoBehaviour
{
    [SerializeField] private bool _isSelf = false;
    [SerializeField] private Pbm.Seat _seat;
    [SerializeField] private Image _profileImage;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _rateText;
    [SerializeField] private TMP_Text _previousBetAmount;
    [SerializeField] private Image _betImage;
    [SerializeField] private TMP_Text _resultText;
    [SerializeField] private TMP_Text _resultAmount;
    [SerializeField] private TMP_Text _waitPlayerText;
    [SerializeField] private GameObject _cardGroup;
    [SerializeField] private GameObject _timerGroup;
    [SerializeField] private GameObject _resultGroup;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _timerText;

    public Image ProfileImage { get { return _profileImage; } set { _profileImage = value; } }
    public TMP_Text NameText { get { return _nameText; } set { _nameText = value; } }
    public TMP_Text RateText { get { return _rateText; } set { _rateText = value; } }
    public TMP_Text PreviousBetAmount { get { return _previousBetAmount; } set { _previousBetAmount = value; } }
    public Image BetImage { get { return _betImage; } set { _betImage = value; } }
    public TMP_Text ResultText { get { return _resultText; } set { _resultText = value; } }
    public TMP_Text ResultAmount { get { return _resultAmount; } set { _resultAmount = value; } }
    public TMP_Text WaitPlayerText { get { return _waitPlayerText; } set { _waitPlayerText = value; } }
    public GameObject CardGroup { get { return _cardGroup; } set { _cardGroup = value; } }
    public GameObject TimerGroup { get { return _timerGroup; } set { _timerGroup = value; } }
    public GameObject ResultGroup { get { return _resultGroup; } set { _resultGroup = value; } }
    public Slider Slider { get { return _slider; } set { _slider = value; } }
    public TMP_Text TimerText { get { return _timerText; } set { _timerText = value; } }

    private int _dealCardCount = 0;

    private void Start()
    {
        StartTimer();
        Initialize();
    }

    public void Deal()
    {
        StartCoroutine(DealCard());
    }

    IEnumerator DealCard()
    {
        yield return new WaitForSeconds(0.01f);
        var rect = _cardGroup.GetComponent<RectTransform>();
        var root = gameObject.transform.root.root.GetComponent<RectTransform>();

        var bound = RectTransformUtility.CalculateRelativeRectTransformBounds(root, rect);
        var cX = bound.center.x - bound.extents.x;
        var cY = bound.center.y;

        var card = GameManager.Resource.Instantiate("Prefabs/PlayCard");
        card.transform.SetParent(gameObject.transform.root.root.root, false);

        var gap = _isSelf ? 75f : 46.67f;
        var scale = _isSelf ? 1f : 0.6365f;

        var cardRectTransform = card.GetComponent<RectTransform>();
        cardRectTransform.anchorMin = Vector2.one * 0.5f;
        cardRectTransform.anchorMax = Vector2.one * 0.5f;
        cardRectTransform.pivot = new Vector2(0, 0.5f);
        cardRectTransform.localScale = Vector3.one * scale;
        cardRectTransform.anchoredPosition = new Vector2(0, 800f);
        cardRectTransform.DOAnchorPos(new Vector2(cX + (_dealCardCount * gap), cY), 0.2f).SetEase(Ease.OutQuad);

        _dealCardCount++;
    }

    private void Initialize()
    {
        _dealCardCount = 0;
        _profileImage.sprite = null;
        _nameText.text = string.Empty;
        _rateText.text = string.Empty;

        _profileImage.gameObject.SetActive(false);
        _nameText.gameObject.SetActive(false);
        _rateText.gameObject.SetActive(false);

        for (int i = 0; i < _cardGroup.transform.childCount; i++)
        {
            Destroy(_cardGroup.transform.GetChild(i).gameObject);
        }
        _timerGroup.SetActive(false);
        _resultGroup.SetActive(false);

    }

    private void OnEnable()
    {
        GameManager.Event.OnResTimer += Event_OnResTimer;
    }

    private void OnDisable()
    {
        GameManager.Event.OnResTimer -= Event_OnResTimer;
    }

    private void Event_OnResTimer(object sender, ResTimer e)
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
}
