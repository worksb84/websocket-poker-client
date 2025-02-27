using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _symbol;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _change;
    [SerializeField] private TMP_Text _changeRate;

    public Image Image { get { return _image; } set { _image = value; } }
    public TMP_Text Name { get { return _name; } set { _name = value; } }
    public TMP_Text Symbol { get { return _symbol; } set { _symbol = value; } }
    public TMP_Text Price { get { return _price; } set { _price = value; } }
    public TMP_Text Change { get { return _change; } set { _change = value; } }
    public TMP_Text ChangeRate { get { return _changeRate; } set { _changeRate = value; } }
}
