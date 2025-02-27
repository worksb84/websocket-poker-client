using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyTopGroup : MonoBehaviour
{
    [SerializeField] private Image _profileImage;
    [SerializeField] private TMP_Text _profileNameText;
    [SerializeField] private TMP_Text _gameResultText;
    [SerializeField] private TMP_Text _moneyText;

    public Image profileImage {get { return _profileImage;} set { _profileImage = value;}}
    public TMP_Text profileNameText {get { return _profileNameText;} set { _profileNameText = value;}}
    public TMP_Text gameResultText {get { return _gameResultText;} set { _gameResultText = value;}}
    public TMP_Text MoneyText { get { return _moneyText; } set { _moneyText = value; } }

    internal void Initialize()
    {

    }

    private void Start()
    {
    }
}
