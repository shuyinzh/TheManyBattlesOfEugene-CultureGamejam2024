﻿public class EugeneIntentSwitcherCard : BaseCard
{
    public Intent Intent;
    public override void whenPlayed()
    {
        battleManager.playEuegeneIntentSwitcherCard(Intent);
    }
}