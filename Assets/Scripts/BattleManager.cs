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
        playerHealthText.text = player.Health.currentHP + " / " + player.Health.maxHP;
        enemyHealthText.text = enemy.Health.currentHP + " / " + enemy.Health.maxHP;

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
