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
    public GameObject cardHand;

    private const string ATTACK = "attack";
    private const string DEFENSE = "defense";
    public Animator eugeneAnimator;
    public Animator enemyAnimator;

    public List<GameObject> Hand = new List<GameObject>();

    private BattleState state = BattleState.Initial;

    void Start()
    {
        Player.StartMatch();

        state = BattleState.PlayerTurn;

        Hand = Player.deckSystem.Hand;
        for (int i = 0; i < Hand.Count; i++)
        {
            GameObject o = Instantiate(Hand[i], new Vector3(-5 + i * 2.25f, -3f, 0), Quaternion.identity, cardHand.transform);
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
                // when attack -> eugeneAnimator.SetTrigger(ATTACK)
                // when enemy defense -> enemyAnitmaor.SetTrigger(DEFENSE)

            // eugene action

            // enemy action, apply effects
        }
    }

    void Update()
    {
        
    }
}
