using System.Collections.Generic;
using UnityEngine;

public class AttackCard : BaseCard{
    public int attackValue = 0;
    public int newAttackModifier;
    public override void whenPlayed()
    {
        if (attackValue == 0)
        {
            battleManager.playAttackModifier(newAttackModifier);
        }
        else
        {
            
            battleManager.playAttackCard(attackValue);
        }
    }
    
}