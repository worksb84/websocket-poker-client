using System;
using System.Collections.Generic;
using System.Diagnostics;
using Best.WebSockets;
using Best.WebSockets.Implementations;
using Google.Protobuf;

public class NetworkManager
{
    private WebSocket _webSocket = null;
    public WebSocket Websocket { get { return _webSocket; } }
    private Dictionary<Pbm.ID, (Func<string, IMessage>, Action<IMessage>)> _funcMap = new();

    public NetworkManager()
    {
        _funcMap.Add(Pbm.ID.ResSeat, (Utils.Unmarshal<Pbm.ResSeat>, GameManager.Event.OnResSeatEvent));
        _funcMap.Add(Pbm.ID.ResBet, (Utils.Unmarshal<Pbm.ResBet>, GameManager.Event.OnResBetEvent));
        _funcMap.Add(Pbm.ID.ResBullBear, (Utils.Unmarshal<Pbm.ResBullBear>, GameManager.Event.OnResBullBearEvent));
        _funcMap.Add(Pbm.ID.ResBullBearReady, (Utils.Unmarshal<Pbm.ResBullBearReady>, GameManager.Event.OnResBullBearReadyEvent));
        _funcMap.Add(Pbm.ID.ResDealCard, (Utils.Unmarshal<Pbm.ResDealCard>, GameManager.Event.OnResDealCardEvent));
        _funcMap.Add(Pbm.ID.ResDealStreet3Card, (Utils.Unmarshal<Pbm.ResDealStreet3Card>, GameManager.Event.OnResDealStreet3CardEvent));
        _funcMap.Add(Pbm.ID.ResEnableBet, (Utils.Unmarshal<Pbm.ResEnableBet>, GameManager.Event.OnResEnableBetEvent));
        _funcMap.Add(Pbm.ID.ResGameStart, (Utils.Unmarshal<Pbm.ResGameStart>, GameManager.Event.OnResGameStartEvent));
        _funcMap.Add(Pbm.ID.ResJoinPlayer, (Utils.Unmarshal<Pbm.ResJoinPlayer>, GameManager.Event.OnResJoinPlayerEvent));
        _funcMap.Add(Pbm.ID.ResRegistPlayer, (Utils.Unmarshal<Pbm.ResRegistPlayer>, GameManager.Event.OnResRegistPlayerEvent));
        _funcMap.Add(Pbm.ID.ResLeave, (Utils.Unmarshal<Pbm.ResLeave>, GameManager.Event.OnResLeaveEvent));
        _funcMap.Add(Pbm.ID.ResMoveRoom, (Utils.Unmarshal<Pbm.ResMoveRoom>, GameManager.Event.OnResMoveRoomEvent));
        _funcMap.Add(Pbm.ID.ResOtherPlayers, (Utils.Unmarshal<Pbm.ResOtherPlayers>, GameManager.Event.OnResOtherPlayersEvent));
        _funcMap.Add(Pbm.ID.ResReady, (Utils.Unmarshal<Pbm.ResReady>, GameManager.Event.OnResReadyEvent));
        _funcMap.Add(Pbm.ID.ResResult, (Utils.Unmarshal<Pbm.ResResult>, GameManager.Event.OnResResultEvent));
        _funcMap.Add(Pbm.ID.ResSelectOpenCard, (Utils.Unmarshal<Pbm.ResSelectOpenCard>, GameManager.Event.OnResSelectOpenCardEvent));
        _funcMap.Add(Pbm.ID.ResShuffleCard, (Utils.Unmarshal<Pbm.ResShuffleCard>, GameManager.Event.OnResShuffleCardEvent));
        _funcMap.Add(Pbm.ID.ResStartStreet, (Utils.Unmarshal<Pbm.ResStartStreet>, GameManager.Event.OnResStartStreetEvent));
        _funcMap.Add(Pbm.ID.ResStreetBoss, (Utils.Unmarshal<Pbm.ResStreetBoss>, GameManager.Event.OnResStreetBossEvent));
        _funcMap.Add(Pbm.ID.ResTimer, (Utils.Unmarshal<Pbm.ResTimer>,  GameManager.Event.OnResTimerEvent));
        _funcMap.Add(Pbm.ID.ResTableInformation, (Utils.Unmarshal<Pbm.ResTableInformation>, GameManager.Event.OnResTableInformationEvent));
        _funcMap.Add(Pbm.ID.ResChoiceCard, (Utils.Unmarshal<Pbm.ResChoiceCard>, GameManager.Event.OnResChoiceCardEvent));
    }

    public void Connect(string address, OnWebSocketOpenDelegate OnOpen)
    {
        if (_webSocket == null)
        {
            _webSocket = new WebSocket(new Uri(address));
            _webSocket.OnOpen += OnOpen;
            _webSocket.OnClosed += OnClosed;
            _webSocket.OnMessage += OnMessage;
            _webSocket.Open();
        }
    }

    private void OnMessage(WebSocket webSocket, string message)
    {
        var messages = message.Split('\n');
        foreach (var m in messages)
        {
            var msg = Utils.Unmarshal<Pbm.Message>(m);
            BufferQueue.Instance.Push(msg);
        }
    }

    private void OnClosed(WebSocket webSocket, WebSocketStatusCodes code, string message)
    {
        Disconnect();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void Send(IMessage message)
    {
        if (_webSocket.IsOpen)
        {
            var jsonString = Utils.Marshal(message);
            UnityEngine.Debug.Log(jsonString);
            _webSocket.Send(jsonString);
        };
    }


    public void Update()
    {
        var buffers = BufferQueue.Instance.Pop();
        foreach (var buffer in buffers)
        {
            if(_funcMap.TryGetValue((Pbm.ID)buffer.Id, out (Func<string, IMessage>, Action<IMessage>) _value))
            {
                var (unmarshal, action) = _value;
                var message = unmarshal(buffer.Body);
                action(message);
            }
        }
    }

    public void Disconnect()
    {
        _webSocket.Close();
    }
}