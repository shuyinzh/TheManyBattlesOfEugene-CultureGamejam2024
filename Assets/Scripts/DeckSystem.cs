using System.Collections.Generic;
using UnityEngine;

public class DeckSystem : MonoBehaviour
{
    
    private const int MAX_HAND_SIZE = 5;
    private const int MIN_DECK_SIZE = 5;
    private const int MAX_DECK_SIZE = 10;
    
    
    public List<Card> Deck = new()
    {
        Cards.Attack,
        Cards.Attack,
        Cards.Defense,
        Cards.Defense,
        Cards.Taunt,
    }; 
    public List<Card> DrawPile = new()
    {
        Cards.Taunt,
        Cards.Taunt,
        Cards.Taunt,
        Cards.Taunt,
    };
    public List<Card> Hand = new()
    {
        Cards.Attack,        Cards.Attack,        Cards.Attack,        Cards.Attack,
    };
    public List<Card> DiscardPile = new(){Cards.Defense,Cards.Defense,Cards.Defense,};
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DrawCards(int numCards = MAX_HAND_SIZE)
    {
        for (int i = 0; i < numCards; i++)
        {
            DrawCard();
        }
    }
   
    public void DrawCard()
    {
        if (DrawPile.Count > 0)
        {
            var drawnCard = DrawPile[0];
            DrawPile.RemoveAt(0);
            if (Hand.Count >= MAX_HAND_SIZE)
            {
                DiscardPile.Add(drawnCard);
            } else {
                Hand.Add(drawnCard);
            }
            
        }
        else
        {
            ShuffleDiscardPileIntoDeck();
            DrawCard();
        }
    }
    
    public void ShuffleDiscardPileIntoDeck()
    {
        DrawPile.AddRange(DiscardPile);
        DiscardPile.Clear();
        ShuffleDrawPile();
    }
    
    public void ShuffleDrawPile()
    {
        for (int i = 0; i < DrawPile.Count; i++)
        {
            Card temp = Deck[i];
            int randomIndex = Random.Range(i, DrawPile.Count);
            DrawPile[i] = Deck[randomIndex];
            DrawPile[randomIndex] = temp;
        }
    }
    
    
    public void PlayHandCard(int index)
    {
        if (index >= 0 && index < Hand.Count)
        {
            Card card = Hand[index];
            Hand.RemoveAt(index);
            DiscardPile.Add(card);
            applyCardEffect(card);
        }
    }

    private void applyCardEffect(Card card)
    {
        throw new System.NotImplementedException();
    }
    
    public void DiscardHand()
    {
        DiscardPile.AddRange(Hand);
        Hand.Clear();
    }

    public void StartMatch()
    {
        DiscardPile.Clear();
        DrawPile.Clear();
        Hand.Clear();
        DrawPile.AddRange(Deck);
        ShuffleDrawPile();
        DrawCards();
        
    }
}
