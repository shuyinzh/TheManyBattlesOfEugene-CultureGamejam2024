using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class BattleManager : MonoBehaviour
{
    public Player Player;
    public NPC Eugene;
    public NPC Enemy;
    public TMP_Text playerHealthText; 
    public TMP_Text enemyHealthText; 

    void Start()
    {
        // load infos
        playerHealthText.text = Eugene.Health.currentHP + " / " + Eugene.Health.maxHP;
        enemyHealthText.text = Enemy.Health.currentHP + " / " + Enemy.Health.maxHP;

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
