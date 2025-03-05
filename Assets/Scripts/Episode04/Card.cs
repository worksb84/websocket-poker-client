using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    [Header("Images")]
    [SerializeField] private Image _image;

    [Header("Texts")]
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _exchange;
    [SerializeField] private TMP_Text _symbol;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _change;
    [SerializeField] private TMP_Text _changeRate;

    [Header("GameObjects")]
    [SerializeField] private GameObject _back;

    [Header("Conceal")]
    [SerializeField] private bool _conceal = true;

    private Pbm.Card _card;

    public Image Image { get { return _image; } set { _image = value; } }
    public TMP_Text Name { get { return _name; } set { _name = value; } }
    public TMP_Text Exchange { get { return _exchange; } set { _exchange = value; } }
    public TMP_Text Symbol { get { return _symbol; } set { _symbol = value; } }
    public TMP_Text Price { get { return _price; } set { _price = value; } }
    public TMP_Text Change { get { return _change; } set { _change = value; } }
    public TMP_Text ChangeRate { get { return _changeRate; } set { _changeRate = value; } }
    public GameObject Back { get { return _back; } set { _back = value; } }
    public bool Conceal { get { return _conceal; } set { _conceal = value; } }
    public Pbm.Card Card_ { get { return _card; } set { _card = value; } }

    public abstract void SetCard(Pbm.Card card);

    public abstract void SetFlip(bool flip);
}
