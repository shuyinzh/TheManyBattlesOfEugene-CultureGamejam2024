using System.Collections.Generic;
using UnityEngine;

public class ZeitgeistAndDrawCard : BaseCard{
    public int zeitgeistValue;
    public int drawValue;
    public override void whenPlayed()
    {
        battleManager.playZeitgeistCard(zeitgeistValue);
        battleManager.playDrawCard(drawValue);
    }
    
}