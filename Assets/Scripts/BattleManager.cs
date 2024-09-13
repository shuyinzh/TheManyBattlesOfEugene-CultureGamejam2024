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
    public TMP_Text eugeneName;
    public TMP_Text enemyName;
    public GameObject cardHand;

    public List<GameObject> Hand = new List<GameObject>();

    private BattleState state = BattleState.Initial;

    void Start()
    {
        // load infos
        playerHealthText.text = Eugene.Health.currentHP + " / " + Eugene.Health.maxHP;
        enemyHealthText.text = Enemy.Health.currentHP + " / " + Enemy.Health.maxHP;
        eugeneName.text = Eugene.Name;
        enemyName.text = Enemy.Name;

        Player.StartMatch();

        state = BattleState.PlayerTurn;

        Hand = Player.deckSystem.Hand;
        for (int i = 0; i < Hand.Count; i++)
        {
            GameObject o = Instantiate(Hand[i], new Vector3(-5+i*2.5f,-3f,0), Quaternion.identity, cardHand.transform);
            o.transform.Find("Canvas").GetComponent<Canvas>().overrideSorting = true;
        }
        foreach (GameObject item in Hand)
        {

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
