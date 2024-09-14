using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class BattleManager : MonoBehaviour
{
    public Player Player;
    public NPC Eugene;
    public NPC Enemy;
    public GameObject cardHand;
    public DeckSystem deckSystem;

    private const string ATTACK = "attack";
    private const string DEFENSE = "defense";
    public Animator eugeneAnimator;
    public Animator enemyAnimator;

    public List<GameObject> Hand = new List<GameObject>();
    public List<GameObject> HandCardObjects = new List<GameObject>();


    private void OnEnable()
    {
        HandCardInteractable.OnCardPlayed += PlayCard;
    }

    private void OnDisable()
    {
        HandCardInteractable.OnCardPlayed -= PlayCard;
    }

    void PlayCard(GameObject playedCard)
    {
        Debug.Log("played card: " + playedCard);

        for (int i = 0; i < Hand.Count; i++)
        {
            if (HandCardObjects[i] == playedCard)
            {
                deckSystem.PlayHandCard(i);
            }
        }
        playedCard.GetComponent<BaseCard>().whenPlayed();

        // update hand
        UpdateHand();
    }

    void Start()
    {
        Player.StartMatch();
        
        Eugene.StartMatch();
        Enemy.StartMatch();

        onPlayerRound();
        
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

    // Call on player turn
    void onPlayerRound()
    {
        Player.StartRound();

        UpdateHand();

        NpcApplyEffects();
    }

    void NpcApplyEffects()
    {
        SetNpcIntents();
        
        Eugene.StartRound();
        Enemy.StartRound();
    }

    void SetNpcIntents()
    {
        Eugene.CreateRandomIntent();
        Enemy.CreateRandomIntent();
    }

    // Call on npc turn
    public void onNpcTurn()
    {
        // discard player hand
        deckSystem.DiscardHand();
        UpdateHand();

        if (Eugene.CurrentIntent == Intent.Defend)
        {
            Eugene.Defense += Eugene.AdditionalDefenseOnDefense;
            Eugene.Defense *= Eugene.RepeatAction;
            eugeneAnimator.SetTrigger(DEFENSE);
        } 
        if(Enemy.CurrentIntent == Intent.Defend)
        {
            Enemy.Defense += Enemy.AdditionalDefenseOnDefense;
            Enemy.Defense *= Enemy.RepeatAction;
            enemyAnimator.SetTrigger(DEFENSE);
        }
        
        if(Eugene.CurrentIntent == Intent.Attack)
        {
            for(int i = 0; i < Eugene.RepeatAction; i++)
            {
                Eugene.Attack(Enemy);
                eugeneAnimator.SetTrigger(ATTACK);
            }
            
        }
        if (Enemy.CurrentIntent == Intent.Attack)
        {
            for(int i = 0; i < Enemy.RepeatAction; i++)
            {
                Enemy.Attack(Eugene);
                enemyAnimator.SetTrigger(ATTACK);
            }
        }
    }
    
    private void UpdateHand()
    {
        ClearHand();
        Hand = deckSystem.Hand;
        for (int i = 0; i < Hand.Count; i++)
        {
            GameObject handCard = Instantiate(Hand[i], new Vector3(-5+i*2.5f,-3f,0), Quaternion.identity, cardHand.transform);
            handCard.transform.Find("Canvas").GetComponent<Canvas>().overrideSorting = true;
            handCard.AddComponent<HandCardInteractable>();
            var card = handCard.GetComponent<BaseCard>();
            card.battleManager = this;
            HandCardObjects.Add(handCard);
        }
    }

    private void ClearHand()
    {
        foreach (GameObject o in HandCardObjects)
        {
            Destroy(o);
        }
        HandCardObjects = new List<GameObject>();
    }

    public void playDefenseCard(int defense)
    {
        Eugene.Defense += defense;
        
    }
    
    public void playAttackCard(int attack)
    {
        Eugene.AdditionalAttack += attack;
    }

    public void playAttackModifier(double newAttackModifier)
    {
        Eugene.AttackModifier *= newAttackModifier;
    }

    public void playDiscardCard()
    {
        deckSystem.DiscardHand();
    }

    public void playCharmeCard(int charmValue)
    {
        Enemy.charmed += charmValue;
    }

    public void playZeitgeistCard(int zeitgeistValue)
    {
        Player.Zeitgeist += zeitgeistValue;
    }

    public void playZeitgeistModifier(double zeitgeistModifier)
    {
        Player.ZeitgeistModifier = zeitgeistModifier;
    }

    public void playIntentSwitcherCard()
    {
        Eugene.SwitchIntent();
        Enemy.SwitchIntent();
        
    }

    public void playZeitgeistMaxCard(int zeitgeistMaxValue)
    {
        Player.AdditionalZeitgeist = zeitgeistMaxValue;
    }

    public void playRepeatActionCard(int repeatValue)
    {
        
        Eugene.RepeatAction = repeatValue;
    }

    public void playDrawCard(int drawValue)
    {
        deckSystem.DrawCards(drawValue);
    }

    public void playEugeneIntentSwitcherCard(Intent intent)
    {
        Eugene.SwitchIntent(intent);
    }

    public void playSleepCard(int sleepValue)
    {
        Enemy.sleep += sleepValue;
    }
}
