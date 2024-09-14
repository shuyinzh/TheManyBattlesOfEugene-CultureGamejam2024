using System.Collections.Generic;
using UnityEngine;

public class ZeitgeistCard : BaseCard
{
    public int zeitgeistValue;
    public double zeitgeistModifier;
    public int ZeitgeistMaxValue = 0;

    public override void whenPlayed()
    {
        if (zeitgeistValue != 0)
        {
            battleManager.playZeitgeistCard(zeitgeistValue);
          
        } else if(ZeitgeistMaxValue != 0)
        {
            battleManager.playZeitgeistMaxCard(ZeitgeistMaxValue);
        }
        else
        {  battleManager.playZeitgeistModifier(zeitgeistModifier);
        }
    }
}