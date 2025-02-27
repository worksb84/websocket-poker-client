using TMPro;
using UnityEngine;

public class HiLoButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _hiLoText;

    public TMP_Text _HiLoText { get { return _hiLoText; } set { _hiLoText = value; } }
}
