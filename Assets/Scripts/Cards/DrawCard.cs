using System.Collections.Generic;
using UnityEngine;

public class DrawCard : BaseCard
{
    public int drawValue;
    
    public override void whenPlayed()
    {
        battleManager.playDrawCard(drawValue);
    }
}