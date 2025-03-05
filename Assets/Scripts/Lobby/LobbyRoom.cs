using UnityEngine;

public abstract class LobbyRoom : MonoBehaviour
{
    [Header("Defines")]
    [SerializeField] private Pbm.Game _game;
    [SerializeField] private Define.GameRoomType _roomType;
    public Pbm.Game Game { get { return _game; } }
    public Define.GameRoomType RoomType { get { return _roomType; } set { _roomType = value; } }
    public abstract void ButtonAction();
}
