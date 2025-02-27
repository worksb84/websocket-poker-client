using DG.Tweening;
using Pbm;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceGroup : MonoBehaviour
{
    [SerializeField] private PlayCard _playCard1;
    [SerializeField] private PlayCard _playCard2;
    [SerializeField] private PlayCard _playCard3;
    [SerializeField] private GameObject _timer;

    private List<PlayCard> _playCards = new();

    public PlayCard PlayCard1 { get { return _playCard1; } set { _playCard1 = value; } }
    public PlayCard PlayCard2 { get { return _playCard2; } set { _playCard2 = value; } }
    public PlayCard PlayCard3 { get { return _playCard3; } set { _playCard3 = value; } }

    private void Start()
    {
        _playCards.Clear();
        _playCards.Add(_playCard1);
        _playCards.Add(_playCard2);
        _playCards.Add(_playCard3);

        _timer.SetActive(false);
        StartTimer();
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
        if(e.Time == 5)
        {
            StartTimer();
        }
    }

    public void Event_OnResDealStreet3Card(ResDealStreet3Card e)
    {
        for (int i = 0; i < _playCards.Count; i++)
        {
            _playCards[i].SetCard(e.Cards[i]);
            _playCards[i].SetPosition(i * 240f);
            _playCards[i].SetAction(e.Cards[i].S, this);
        }
    }

    internal void Disable()
    {
        gameObject.SetActive(false);
    }

    private void StartTimer()
    {
        var timer = _timer.GetComponent<RectTransform>();
        timer.sizeDelta = new Vector2(700f, 15f);
        _timer.SetActive(true);
        timer.DOSizeDelta(new Vector2(0f, 15f), 5f).SetEase(Ease.Linear).SetLoops(-1);
    }

    private void StopTimer()
    {
        var timer = _timer.GetComponent<RectTransform>();
        timer.DOKill();
    }
}
