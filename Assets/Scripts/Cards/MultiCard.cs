using System.Collections.Generic;
using UnityEngine;

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