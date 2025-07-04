using Best.WebSockets;
using System;
using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Lazy<NetworkManager> _networkManager = new(() => new());
    private Lazy<EventManager> _eventManager = new(() => new());
    private Lazy<SoundManager> _soundManager = new(() => new());
    private Lazy<ResourceManager> _resourceManager = new(() => new());
    private Lazy<RestAPIManager> _restAPIManager = new(() => new());
    public static NetworkManager Network { get { return Instance._networkManager.Value; } }
    public static EventManager Event { get { return Instance._eventManager.Value; } }
    public static SoundManager Sound { get { return Instance._soundManager.Value; } }
    public static ResourceManager Resource { get { return Instance._resourceManager.Value; } }
    public static RestAPIManager RestAPI { get { return Instance._restAPIManager.Value; } }

    private void Start()
    {
        Application.runInBackground = true;
    }

    public void Connect(string tableId)
    {
        Network.Connect($"ws://localhost:8087/table/join/{tableId}", OnOpen);
    }

    private void OnOpen(WebSocket webSocket)
    {
        StartCoroutine(CoNetworkUpdate());
    }

    IEnumerator CoNetworkUpdate()
    {
        while (true)
        {
            Network.Update();
            yield return null;
        }
    }
}
