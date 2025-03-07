using Pbm;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SeatGroup : MonoBehaviour
{
    [Header("Seats")]
    [SerializeField] private Seat _seat1;
    [SerializeField] private Seat _seat2;
    [SerializeField] private Seat _seat3;
    [SerializeField] private Seat _seat4;
    [SerializeField] private Seat _seat5;

    public Seat Seat1 { get { return _seat1; } set { _seat1 = value; } }
    public Seat Seat2 { get { return _seat2; } set { _seat2 = value; } }
    public Seat Seat3 { get { return _seat3; } set { _seat3 = value; } }
    public Seat Seat4 { get { return _seat4; } set { _seat4 = value; } }
    public Seat Seat5 { get { return _seat5; } set { _seat5 = value; } }

    private List<Seat> _seats = new();

    [SerializeField] private float _waitForSeconds = 0.2f;

    private int _anchor = -1;


    private void OnEnable()
    {
        GameManager.Event.OnResBet += Event_OnResBet;
        GameManager.Event.OnResStreetBoss += Event_OnResStreetBoss;
        GameManager.Event.OnResSeat += Event_OnResSeat;
    }

    private void Event_OnResSeat(object sender, ResSeat e)
    {
        foreach (var seat_ in e.Seats)
        {
            var seat = FindBySeat(seat_);
            seat.Seat_ = seat_;
            if (seat.IsSelf)
            {
                Episode04.Instance.Seat = seat_;
            }
        }
    }

    private void OnDisable()
    {
        GameManager.Event.OnResBet -= Event_OnResBet;
        GameManager.Event.OnResStreetBoss -= Event_OnResStreetBoss;
        GameManager.Event.OnResSeat -= Event_OnResSeat;
    }
    private void Start()
    {
        _seats.Clear();
        _seats.Add(_seat1);
        _seats.Add(_seat2);
        _seats.Add(_seat3);
        _seats.Add(_seat4);
        _seats.Add(_seat5);
    }
    private void Event_OnResStreetBoss(object sender, ResStreetBoss e)
    {
        Debug.Log("Event_OnResStreetBoss");
        Debug.Log(e);
        StreetBoss(e);
    }

    internal IEnumerator SetStreet3Card(ResDealStreet3Card e, UnityAction action)
    {
        Debug.Log("SetStreet3Card");
        yield return new WaitForSeconds(_waitForSeconds);
        for (int i = 0; i < e.Cards.Count; i++)
        {
            foreach (var seat in _seats)
            {
                if (seat.Seat_.Seat_ != -1)
                {
                    StartCoroutine(seat.SetDealCard(_waitForSeconds));
                    yield return new WaitForSeconds(_waitForSeconds);
                }
            }
        }

        yield return new WaitForSeconds(e.Cards.Count * _waitForSeconds);
        for (int i = 0; i < e.Cards.Count; i++)
        {
            foreach (var seat in _seats)
            {
                if (seat.Seat_.Seat_ != -1)
                {
                    seat.SetSort();
                }
            }
        }

        var selfSeat = _seats.Find(x => x.IsSelf == true);
        selfSeat.SetCard(e);
        action();
    }

    internal void SetOpenCard(ResSelectOpenCard e)
    {
        foreach (var selectOpenCard in e.SelectOpenCards)
        {
            var seat = FindBySeat(selectOpenCard.Seat);
            seat.SetOpenCard(selectOpenCard);
        }
    }
    private void Event_OnResBet(object sender, ResBet e)
    {
        var seat = FindBySeat(e.Seat);
        seat.SetBet(e);
    }

    internal void StreetBoss(ResStreetBoss e)
    {
        foreach (var _seat in _seats)
        {
            _seat.ResetStreetBoss();
        }
        var seat = FindBySeat(e.Seat);
        seat.SetStreetBoss();
    }

    internal void SetSeat(Player player, bool isSelf)
    {
        if (isSelf)
        {
            _anchor = player.Seat.Seat_;
            Episode04.Instance.Seat = player.Seat;
            Episode04.Instance.Uid = player.Seat.Uid;
        }
        var idx = (player.Seat.Seat_ - _anchor + _seats.Count) % _seats.Count;
        Debug.Log(idx);
        Debug.Log(isSelf);
        var seat = _seats[idx];
        seat.SetSeat(player, isSelf);
    }

    private Seat FindBySeat(Pbm.Seat seat)
    {
        return _seats.Find(x => x.Seat_.Seat_ == seat.Seat_);
    }

    internal void SetPlayer(ResJoinPlayer e)
    {
        SetSeat(e.Player, false);
    }

    internal void SetOtherPlayers(ResOtherPlayers e)
    {
        foreach (var player in e.Players)
        {
            SetSeat(player, false);
        }
    }

    internal IEnumerator SetDealCard(ResDealCard e)
    {
        Debug.Log("SetDealCard");
        yield return new WaitForSeconds(_waitForSeconds);

        foreach (var dealCard in e.DealCards)
        {
            var seat = FindBySeat(dealCard.Seat);

            StartCoroutine(seat.SetDealCard(_waitForSeconds));
            yield return new WaitForSeconds(_waitForSeconds);
        }

        yield return new WaitForSeconds(_waitForSeconds);


        foreach (var seat in _seats)
        {
            if (seat.Seat_.Seat_ != -1)
            {
                seat.SetSort();
            }
        }

        foreach (var dealCard in e.DealCards)
        {
            var seat = FindBySeat(dealCard.Seat);

            seat.SetOpenDealCard(dealCard);
        }
    }
}
