using Pbm;
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

    private void Start()
    {
        _seats.Clear();
        _seats.Add(_seat4);
        _seats.Add(_seat5);
        _seats.Add(_seat1);
        _seats.Add(_seat2);
        _seats.Add(_seat3);
    }


    internal IEnumerator DealStreet3Card(ResDealStreet3Card e, UnityAction action)
    {
        yield return new WaitForSeconds(_waitForSeconds);
        for (int i = 0; i < e.Cards.Count; i++)
        {
            foreach (var seat in _seats)
            {
                if (seat.Seat_.Seat_ != -1)
                {
                    StartCoroutine(seat.SetStreet3Card());
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

    internal void SelectOpenCard(ResSelectOpenCard e)
    {
        foreach (var selectOpenCard in e.SelectOpenCards)
        {
            var seat = FindBySeat(selectOpenCard.Seat);
            seat.SetOpenCard(selectOpenCard);
        }
    }

    internal void Bet(ResBet e)
    {
        var seat = FindBySeat(e.Seat);
        seat.SetBet(e);
    }

    internal void StreetBoss(ResStreetBoss e)
    {
        var seat = FindBySeat(e.Seat);
        seat.SetStreetBoss();
    }

    private Seat FindBySeat(Pbm.Seat seat)
    {
        return _seats.Find(x => x.Seat_.Seat_ == seat.Seat_);
    }
}
