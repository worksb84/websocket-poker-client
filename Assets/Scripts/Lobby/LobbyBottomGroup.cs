using UnityEngine;
using UnityEngine.UI;

public class LobbyBottomGroup : MonoBehaviour
{
    [SerializeField] private Button _profileButton;
    [SerializeField] private Button _itemShopButton;
    [SerializeField] private Button _exchangeButton;
    [SerializeField] private Button _deckButton;
    [SerializeField] private Button _favoriteButton;
    [SerializeField] private Button _chatRoomButton;

    public Button ProfileButton { get { return _profileButton; } set { _profileButton = value; } }
    public Button ItemShopButton { get { return _itemShopButton; } set { _itemShopButton = value; } }
    public Button ExchangeButton { get { return _exchangeButton; } set { _exchangeButton = value; } }
    public Button DeckButton { get { return _deckButton; } set { _deckButton = value; } }
    public Button FavoriteButton { get { return _favoriteButton; } set { _favoriteButton = value; } }
    public Button ChatRoomButton { get { return _chatRoomButton; } set { _chatRoomButton = value; } }

    internal void Initialize()
    {
        ProfileButton.onClick.RemoveAllListeners();
        ItemShopButton.onClick.RemoveAllListeners();
        ExchangeButton.onClick.RemoveAllListeners();
        DeckButton.onClick.RemoveAllListeners();
        FavoriteButton.onClick.RemoveAllListeners();
        ChatRoomButton.onClick.RemoveAllListeners();


        ProfileButton.onClick.AddListener(() => { Debug.Log("ProfileButton"); });
        ItemShopButton.onClick.AddListener(() => { Debug.Log("ItemShopButton"); });
        ExchangeButton.onClick.AddListener(() => { Debug.Log("ExchangeButton"); });
        DeckButton.onClick.AddListener(() => { Debug.Log("DeckButton"); });
        FavoriteButton.onClick.AddListener(() => { Debug.Log("FavoriteButton"); });
        ChatRoomButton.onClick.AddListener(() => { Debug.Log("ChatRoomButton"); });
    }

    private void Start()
    {

    }
}
