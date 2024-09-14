using System.Collections.Generic;
using UnityEngine;

public class SleepCard : BaseCard
{
    public int sleepValue;
    
    public override void whenPlayed()
    {
        battleManager.playSleepCard(sleepValue);
    }
}