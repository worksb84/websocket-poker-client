using TMPro;
using UnityEngine;

public class AmountGroup : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text _totalAmount;
    [SerializeField] private TMP_Text _callAmount;

    public TMP_Text TotalAmount { get { return _totalAmount; } set { _totalAmount = value; } }
    public TMP_Text CallAmount { get { return _callAmount; } set { _callAmount = value; } }
}
