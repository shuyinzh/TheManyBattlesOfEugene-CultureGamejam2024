using System.Collections.Generic;

public class MultiCard : BaseCard
{
    public List<BaseCard> cards;
    
    public override void whenPlayed()
    {
        foreach (BaseCard card in cards)
        {
            card.whenPlayed();
        }
    }
}