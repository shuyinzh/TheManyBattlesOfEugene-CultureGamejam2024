using System.Collections.Generic;
using UnityEngine;

public class CharmeCard : BaseCard
{
    public int charmValue;
    
    public override void whenPlayed()
    {
        battleManager.playCharmeCard(charmValue);
    }
}