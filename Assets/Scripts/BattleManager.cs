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

    // private List<Card> Hand = new List<Card>();

    private BattleState state = BattleState.Initial;

    void Start()
    {
        // load infos
        playerHealthText.text = Eugene.Health.currentHP + " / " + Eugene.Health.maxHP;
        enemyHealthText.text = Enemy.Health.currentHP + " / " + Enemy.Health.maxHP;

        Player.StartMatch();

        state = BattleState.PlayerTurn;

        //Hand = Player.DeckSystem.Hand;
        /*foreach (Card item in Hand)
        {
            // Instantiate(item, cardHand);
        }
        */
        
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
