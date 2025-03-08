using Google.Protobuf;
using System;

public class EventManager
{
    public event EventHandler<Pbm.ResSeat> OnResSeat;
    public event EventHandler<Pbm.ResBet> OnResBet;
    public event EventHandler<Pbm.ResBullBear> OnResBullBear;
    public event EventHandler<Pbm.ResBullBearReady> OnResBullBearReady;
    public event EventHandler<Pbm.ResDealCard> OnResDealCard;
    public event EventHandler<Pbm.ResDealStreet3Card> OnResDealStreet3Card;
    public event EventHandler<Pbm.ResEnableBet> OnResEnableBet;
    public event EventHandler<Pbm.ResGameStart> OnResGameStart;
    public event EventHandler<Pbm.ResJoinPlayer> OnResJoinPlayer;
    public event EventHandler<Pbm.ResRegistPlayer> OnResRegistPlayer;
    public event EventHandler<Pbm.ResLeave> OnResLeave;
    public event EventHandler<Pbm.ResMoveRoom> OnResMoveRoom;
    public event EventHandler<Pbm.ResOtherPlayers> OnResOtherPlayers;
    public event EventHandler<Pbm.ResReady> OnResReady;
    public event EventHandler<Pbm.ResResult> OnResResult;
    public event EventHandler<Pbm.ResSelectOpenCard> OnResSelectOpenCard;
    public event EventHandler<Pbm.ResShuffleCard> OnResShuffleCard;
    public event EventHandler<Pbm.ResStartStreet> OnResStartStreet;
    public event EventHandler<Pbm.ResStreetBoss> OnResStreetBoss;
    public event EventHandler<Pbm.ResTimer> OnResTimer;
    public event EventHandler<Pbm.ResTableInformation> OnResTableInformation;

    public void OnResSeatEvent(IMessage res) => OnResSeat?.Invoke(this, (Pbm.ResSeat)res);
    public void OnResBetEvent(IMessage res) => OnResBet?.Invoke(this, (Pbm.ResBet)res);
    public void OnResBullBearEvent(IMessage res) => OnResBullBear?.Invoke(this, (Pbm.ResBullBear)res);
    public void OnResBullBearReadyEvent(IMessage res) => OnResBullBearReady?.Invoke(this, (Pbm.ResBullBearReady)res);
    public void OnResDealCardEvent(IMessage res) => OnResDealCard?.Invoke(this, (Pbm.ResDealCard)res);
    public void OnResDealStreet3CardEvent(IMessage res) => OnResDealStreet3Card?.Invoke(this, (Pbm.ResDealStreet3Card)res);
    public void OnResEnableBetEvent(IMessage res) => OnResEnableBet?.Invoke(this, (Pbm.ResEnableBet)res);
    public void OnResGameStartEvent(IMessage res) => OnResGameStart?.Invoke(this, (Pbm.ResGameStart)res);
    public void OnResJoinPlayerEvent(IMessage res) => OnResJoinPlayer?.Invoke(this, (Pbm.ResJoinPlayer)res);
    public void OnResRegistPlayerEvent(IMessage res) => OnResRegistPlayer?.Invoke(this, (Pbm.ResRegistPlayer)res);
    public void OnResLeaveEvent(IMessage res) => OnResLeave?.Invoke(this, (Pbm.ResLeave)res);
    public void OnResMoveRoomEvent(IMessage res) => OnResMoveRoom?.Invoke(this, (Pbm.ResMoveRoom)res);
    public void OnResOtherPlayersEvent(IMessage res) => OnResOtherPlayers?.Invoke(this, (Pbm.ResOtherPlayers)res);
    public void OnResReadyEvent(IMessage res) => OnResReady?.Invoke(this, (Pbm.ResReady)res);
    public void OnResResultEvent(IMessage res) => OnResResult?.Invoke(this, (Pbm.ResResult)res);
    public void OnResSelectOpenCardEvent(IMessage res) => OnResSelectOpenCard?.Invoke(this, (Pbm.ResSelectOpenCard)res);
    public void OnResShuffleCardEvent(IMessage res) => OnResShuffleCard?.Invoke(this, (Pbm.ResShuffleCard)res);
    public void OnResStartStreetEvent(IMessage res) => OnResStartStreet?.Invoke(this, (Pbm.ResStartStreet)res);
    public void OnResStreetBossEvent(IMessage res) => OnResStreetBoss?.Invoke(this, (Pbm.ResStreetBoss)res);
    public void OnResTimerEvent(IMessage res) => OnResTimer?.Invoke(this, (Pbm.ResTimer)res);
    public void OnResTableInformationEvent(IMessage res) => OnResTableInformation?.Invoke(this, (Pbm.ResTableInformation)res);

}
