using System.Collections.Generic;
using UnityEngine;

public class DiscardAndDrawCard : BaseCard{
    public int drawValue;
    public override void whenPlayed()
    {
        battleManager.playDiscardCard();
        battleManager.playDrawCard(drawValue);
    }
    
}