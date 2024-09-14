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
    public DeckSystem deckSystem;

    private const string ATTACK = "attack";
    private const string DEFENSE = "defense";
    public Animator eugeneAnimator;
    public Animator enemyAnimator;

    public List<GameObject> Hand = new List<GameObject>();
    public List<GameObject> HandCardObjects = new List<GameObject>();

    private BattleState state = BattleState.Initial;

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

        state = BattleState.PlayerTurn;

        UpdateHand();
        
        Eugene.StartMatch();
        Enemy.StartMatch();
        
        
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

    private void UpdateHand()
    {
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

    public void playDefenseCard(int defense)
    {
        Eugene.Defense += defense;
        
    }
    
    public void playAttackCard(int attack)
    {
        Eugene.AdditionalAttack+= attack;
    }

    public void playAttackModifier(double newAttackModifier)
    {
        Eugene.AttackModifier = newAttackModifier;
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
        Eugene.RepeatLastAction = repeatValue;
    }

    public void playDrawCard(int drawValue)
    {
        deckSystem.DrawCards(drawValue);
    }

    public void playEuegeneIntentSwitcherCard(Intent intent)
    {
        Eugene.CurrentIntent = intent;
    }

    public void playSleepCard(int sleepValue)
    {
        Enemy.sleep += sleepValue;
    }
}
