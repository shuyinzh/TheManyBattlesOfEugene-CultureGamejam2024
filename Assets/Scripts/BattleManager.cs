using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public TMP_Text playerHealthText; 
    public TMP_Text enemyHealthText; 

    void Start()
    {
        // load infos
        playerHealthText.text = player.health.currentHP + " / " + player.health.maxHP;
        enemyHealthText.text = enemy.health.currentHP + " / " + enemy.health.maxHP;

        {        
            // player turn
                // draw cards
                // player action: select, 
                // play card, apply effect
                // end turn -> discard hand?

            // eugene action

            // enemy action, apply effects
        }
    }

    void Update()
    {
        
    }
}
