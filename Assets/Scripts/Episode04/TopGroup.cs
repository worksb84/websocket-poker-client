using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopGroup : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text _jackpotText;

    [Header("Images")]
    [SerializeField] private Image _moveRoomText;
    [SerializeField] private Image _leaveText;

    [Header("Buttons")]
    [SerializeField] private Button _moveRoomButton;
    [SerializeField] private Button _leaveButton;

    private bool _reserveLeave = false;
    private bool _reserveMoveRoom = false;

    public TMP_Text JackpotText { get { return _jackpotText; } set { _jackpotText = value; } }
    public Button MoveRoomButton { get { return _moveRoomButton; } set { _moveRoomButton = value; } }
    public Button LeaveButton { get { return _leaveButton; } set { _leaveButton = value; } }
    public bool ReserveLeave { get { return _reserveLeave; } set { _reserveLeave = value; } }
    public bool ReserveMoveRoom { get { return _reserveMoveRoom; } set { _reserveMoveRoom = value; } }
    public Image MoveRoomText { get { return _moveRoomText; } set { _moveRoomText = value; } }
    public Image LeaveText { get { return _leaveText; } set { _leaveText = value; } }
}
