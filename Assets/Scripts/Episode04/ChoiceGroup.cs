using DG.Tweening;
using Pbm;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoiceGroup : MonoBehaviour
{
    [Header("Cards")]
    [SerializeField] private PlayCard _playCard1;
    [SerializeField] private PlayCard _playCard2;
    [SerializeField] private PlayCard _playCard3;

    [Header("Timer")]
    [SerializeField] private RectTransform _timer;

    private List<PlayCard> _playCards = new();

    public PlayCard PlayCard1 { get { return _playCard1; } set { _playCard1 = value; } }
    public PlayCard PlayCard2 { get { return _playCard2; } set { _playCard2 = value; } }
    public PlayCard PlayCard3 { get { return _playCard3; } set { _playCard3 = value; } }

    private void Start()
    {
        _timer.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        GameManager.Event.OnResTimer += Event_OnResTimer;
    }

    private void OnDisable()
    {
        GameManager.Event.OnResTimer -= Event_OnResTimer;
    }

    private void Event_OnResTimer(object sender, Pbm.ResTimer e)
    {
        if (e.Time == 5)
        {
            StartTimer(e.Time);
        }
        if (e.Time <= 0)
        {
            StopTimer();
        }
    }

    private void StartTimer(int v)
    {
        _timer.sizeDelta = new Vector2(700f, 5f);
        _timer.gameObject.SetActive(true);
        _timer.DOSizeDelta(new Vector2(0f, 5f), v).SetEase(Ease.Linear);
    }

    private void StopTimer()
    {
        _timer.DOKill();
        _timer.gameObject.SetActive(false);
    }

    internal void SetCards(Pbm.ResDealStreet3Card e)
    {
        Debug.Log("SetCards Choice");
        _playCards.Clear();
        _playCards.Add(_playCard1);
        _playCards.Add(_playCard2);
        _playCards.Add(_playCard3);

        for (int i = 0; i < e.Cards.Count; i++)
        {
            var card = e.Cards[i];
            var playCard = _playCards[i];
            playCard.SetCard(card);

            var button = playCard.gameObject.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => {
                var req = new Pbm.ReqSelectOpenCard()
                {
                    SelectOpenCard = new Pbm.SelectOpenCard()
                    {
                        Card = card,
                        Seat = Episode04.Instance.Seat
                    }
                };

                GameManager.Network.Send(req);;
            });
        }
    }
}
