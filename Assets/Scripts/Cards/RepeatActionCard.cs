using System.Collections.Generic;
using UnityEngine;

public class RepeatActionCard : BaseCard
{
    public int repeatValue;
    
    public override void whenPlayed()
    {
        battleManager.playRepeatActionCard(repeatValue);
    }
}