using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SeatGroup : MonoBehaviour
{
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

    private void Start()
    {
        _seats.Clear();
        _seats.Add(_seat1);
        _seats.Add(_seat2);
        _seats.Add(_seat3);
        _seats.Add(_seat4);
        _seats.Add(_seat5);
    }
}
