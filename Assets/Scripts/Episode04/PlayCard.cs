using UnityEngine.Events;
using UnityEngine.UI;

public class PlayCard : Card
{
    public override void SetFlip(bool flip)
    {
        Back.SetActive(!flip);
    }

    public override void SetCard(Pbm.Card card)
    {
        Card_ = card;
        Name.text = card.N;
        Exchange.text = card.E;
        Symbol.text = card.S;
        Price.text = card.Cp.ToString();
        Change.text = card.C.ToString();
        ChangeRate.text = card.Cr.ToString("n2");
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
