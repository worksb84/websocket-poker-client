using System;
using DG.Tweening;
using Pbm;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Seat : MonoBehaviour
{
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
    public Slider Slider { get { return _slider; } set { _slider = value; } }
    public TMP_Text TimerText { get { return _timerText; } set { _timerText = value; } }

    private void Start()
    {
        StartTimer();
        Initialize();
    }

    private void Initialize()
    {
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
        if(e.Seat.Seat_ == _seat.Seat_)
        {
            if (e.Time == 5)
            {
                StartTimer();
            }
            if (e.Time <= 0)
            {
                StopTimer();
            }
            if(e.Time <= 5)
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
