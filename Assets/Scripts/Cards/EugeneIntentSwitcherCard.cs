using System.Collections.Generic;
using UnityEngine;

public class EugeneIntentSwitcherCard : BaseCard
{
    public Intent Intent;
    public override void whenPlayed()
    {
        battleManager.playEuegeneIntentSwitcherCard(Intent);
    }
}