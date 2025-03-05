using UnityEngine;
using UnityEngine.UI;

public class LobbyMiddleGroup : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _sevenButton;
    [SerializeField] private Button _bullishBearishButton;
    [SerializeField] private Button _skeletonButton;
    [SerializeField] private Button _midusTouchButton;
    [SerializeField] private Button _ante100RoomButton;
    [SerializeField] private Button _ante200RoomButton;
    [SerializeField] private Button _ante300RoomButton;
    [SerializeField] private Button _anteFreeRoomButton;
    [SerializeField] private Button _anteMakeRoomButton;

    public Button SevenButton { get { return _sevenButton; } set { _sevenButton = value; } }
    public Button BullishBearishButton { get { return _bullishBearishButton; } set { _bullishBearishButton = value; } }
    public Button SkeletonButton { get { return _skeletonButton; } set { _skeletonButton = value; } }
    public Button MidusTouchButton { get { return _midusTouchButton; } set { _midusTouchButton = value; } }
    public Button Ante100RoomButton { get { return _ante100RoomButton; } set { _ante100RoomButton = value; } }
    public Button Ante200RoomButton { get { return _ante200RoomButton; } set { _ante200RoomButton = value; } }
    public Button Ante300RoomButton { get { return _ante300RoomButton; } set { _ante300RoomButton = value; } }
    public Button AnteFreeRoomButton { get { return _anteFreeRoomButton; } set { _anteFreeRoomButton = value; } }
    public Button AnteMakeRoomButton { get { return _anteMakeRoomButton; } set { _anteMakeRoomButton = value; } }

    internal void Initialize()
    {
    }

    private void Start()
    {
        SevenButton.onClick.RemoveAllListeners();
        BullishBearishButton.onClick.RemoveAllListeners();
        SkeletonButton.onClick.RemoveAllListeners();
        MidusTouchButton.onClick.RemoveAllListeners();

        SevenButton.onClick.AddListener(() => { SelectGame(Pbm.Game.Seven); });
        BullishBearishButton.onClick.AddListener(() => { SelectGame(Pbm.Game.BullBear); });
        SkeletonButton.onClick.AddListener(() => { SelectGame(Pbm.Game.Skeleton); });
        MidusTouchButton.onClick.AddListener(() => { SelectGame(Pbm.Game.MidusTouch); });

        Ante100RoomButton.onClick.RemoveAllListeners();
        Ante200RoomButton.onClick.RemoveAllListeners();
        Ante300RoomButton.onClick.RemoveAllListeners();
        AnteFreeRoomButton.onClick.RemoveAllListeners();
        AnteMakeRoomButton.onClick.RemoveAllListeners();

        Ante100RoomButton.onClick.AddListener(() => { SelectRoomButton(Ante100RoomButton.GetComponent<LobbyRoom>(), Define.GameRoomType.A100); });
        Ante200RoomButton.onClick.AddListener(() => { SelectRoomButton(Ante200RoomButton.GetComponent<LobbyRoom>(), Define.GameRoomType.A200); });
        Ante300RoomButton.onClick.AddListener(() => { SelectRoomButton(Ante300RoomButton.GetComponent<LobbyRoom>(), Define.GameRoomType.A300); });
        AnteFreeRoomButton.onClick.AddListener(() => { SelectRoomButton(AnteFreeRoomButton.GetComponent<LobbyRoom>(), Define.GameRoomType.FREE); });
        AnteMakeRoomButton.onClick.AddListener(() => { SelectRoomButton(AnteMakeRoomButton.GetComponent<LobbyRoom>(), Define.GameRoomType.MAKE); });
    }

    private void SelectGame(Pbm.Game game)
    {
        var gameName = game.ToString();
        Debug.Log(gameName);
    }

    private void SelectRoomButton(LobbyRoom lobbyRoom, Define.GameRoomType roomType)
    {
        lobbyRoom.RoomType = roomType;
        lobbyRoom.ButtonAction();
    }
}
