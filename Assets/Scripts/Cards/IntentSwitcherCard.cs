using System.Collections.Generic;
using UnityEngine;

public class IntentSwitcherCard : BaseCard
{
    
    public override void whenPlayed()
    {
        battleManager.playIntentSwitcherCard();
    }
}