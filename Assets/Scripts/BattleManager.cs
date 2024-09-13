using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public enum BattleState
{
    Initial,
    PlayerTurn,
    EugeneTurn,
    EnemyTurn
}

public class BattleManager : MonoBehaviour
{
    public Player Player;
    public NPC Eugene;
    public NPC Enemy;
    public TMP_Text playerHealthText; 
    public TMP_Text enemyHealthText; 
    public GameObject cardHand;

    public List<GameObject> Hand = new List<GameObject>();

    private BattleState state = BattleState.Initial;

    void Start()
    {
        // load infos
        playerHealthText.text = Eugene.Health.currentHP + " / " + Eugene.Health.maxHP;
        enemyHealthText.text = Enemy.Health.currentHP + " / " + Enemy.Health.maxHP;

        Player.StartMatch();

        state = BattleState.PlayerTurn;

        Hand = Player.deckSystem.Hand;
        foreach (GameObject item in Hand)
        { 
            Instantiate(item, new Vector3(0,0,0), Quaternion.identity, cardHand.transform);
        }
        
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
