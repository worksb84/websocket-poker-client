using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyMakeButton : LobbyRoom
{
    public override void ButtonAction()
    {
        Debug.Log(RoomType);
        Debug.Log(Game);

        var req = new Pbm.ReqGenerateTable()
        {
            TableInformation = new Pbm.TableInformation()
            {
                Game = Game,
                Region = "SEC",
                Ante = (uint)RoomType,
            }
        };

        var routine = GameManager.RestAPI.RequestPost<Pbm.ResGenerateTable>(Define.GENERATE_TABLE, req, ResGenerateTable);
        StartCoroutine(routine);
    }

    private void ResGenerateTable(Pbm.ResGenerateTable res)
    {
        var tableId = res.TableInformation.TableId;
        GameManager.Instance.Connect(tableId);
        SceneManager.LoadScene("Episode04");
    }
}
