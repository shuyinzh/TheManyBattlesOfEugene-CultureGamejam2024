using System.Collections.Generic;
using UnityEngine;

public class DiscardHandCard : BaseCard
{
    public override void whenPlayed()
    {
        battleManager.playDiscardCard();
    }
}