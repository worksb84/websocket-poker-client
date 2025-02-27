using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    private static LobbyManager _instance;
    [SerializeField] private LobbyTopGroup _lobbyTopGroup;
    [SerializeField] private LobbyMiddleGroup _lobbyMiddleGroup;
    [SerializeField] private LobbyBottomGroup _lobbyBottomGroup;

    public static LobbyManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj;
                obj = GameObject.Find(typeof(LobbyManager).Name);
                if (obj == null)
                {
                    obj = new GameObject(typeof(LobbyManager).Name);
                    _instance = obj.AddComponent<LobbyManager>();
                }
                else
                {
                    _instance = obj.GetComponent<LobbyManager>();
                }
            }
            return _instance;
        }
    }
    public static LobbyTopGroup TopGroup { get { return Instance._lobbyTopGroup; } }
    public static LobbyMiddleGroup MiddleGroup { get { return Instance._lobbyMiddleGroup; } }
    public static LobbyBottomGroup BottomGroup { get { return Instance._lobbyBottomGroup; } }

    public void Initialize()
    {
        TopGroup.Initialize();
        MiddleGroup.Initialize();
        BottomGroup.Initialize();
    }
}
