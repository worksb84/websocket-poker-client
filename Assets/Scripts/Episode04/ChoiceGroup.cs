using UnityEngine;
using UnityEngine.UI;

public class ChoiceGroup : MonoBehaviour
{
    [SerializeField] private PlayCard _playCard1;
    [SerializeField] private PlayCard _playCard2;
    [SerializeField] private PlayCard _playCard3;

    public PlayCard PlayCard1 { get { return _playCard1; } set { _playCard1 = value; } }
    public PlayCard PlayCard2 { get { return _playCard2; } set { _playCard2 = value; } }
    public PlayCard PlayCard3 { get { return _playCard3; } set { _playCard3 = value; } }
}
