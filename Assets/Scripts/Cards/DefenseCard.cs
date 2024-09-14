using System.Collections.Generic;
using UnityEngine;

class DefenseCard : BaseCard
{
    public int defenseValue;
    
    public override void whenPlayed()
    {
        battleManager.playDefenseCard(defenseValue);
    }
}