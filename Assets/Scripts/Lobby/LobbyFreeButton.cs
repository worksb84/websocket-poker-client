using UnityEngine;

public class LobbyFreeButton : LobbyRoom
{
    public override void ButtonAction()
    {
        Debug.Log(RoomType);
        Debug.Log(Game);
    }
}
