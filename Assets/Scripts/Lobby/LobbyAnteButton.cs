using UnityEngine;

public class LobbyAnteButton : LobbyRoom
{
    public override void ButtonAction()
    {
        Debug.Log(RoomType);
        Debug.Log(Game);
    }
}
