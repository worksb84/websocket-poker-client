using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayCard : Card
{
    public override void SetCard(Pbm.Card card)
    {
        Name.text = card.N;
        Exchange.text = card.E;
        Symbol.text = card.S;
        Price.text = card.Cp.ToString();
        Change.text = card.C.ToString();
        ChangeRate.text = card.Cr.ToString("n2");
    }

    public override void SetPosition(float x)
    {
        var rect = gameObject.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(x, 0f);

    }

    internal void SetAction(string symbol, ChoiceGroup choiceGroup)
    {
        var button = gameObject.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => { SelectOpenCard(symbol, choiceGroup); });
    }

    private void SelectOpenCard(string symbol, ChoiceGroup choiceGroup)
    {
        var req = new Pbm.ReqSelectOpenCard()
        {
            SelectOpenCard = new Pbm.SelectOpenCard()
            {
                Symbol = symbol,
                Seat = new Pbm.Seat()
                {
                    Uid = 1,
                    Seat_ = 1
                },
            }
        };

        choiceGroup.Disable();
    }

    // 0.6365 Scale
    // -173.33 OtherCardGroupGap
    // 46.67 PosX
    // 75 PosX
    private void Start()
    {
        if(gameObject.TryGetComponent<Button>(out Button button))
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
