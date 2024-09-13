using System.Collections.Generic;
using UnityEngine;

public class DeckSystem : MonoBehaviour
{
    
    private static int MAX_HAND_SIZE = 5;
    private static int MAX_DECK_SIZE = 10;
    
    private List<Card> deck;
    private List<Card> hand;
    private List<Card> discardPile;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DrawCard()
    {
        if (deck.Count > 0)
        {
            hand.Add(deck[0]);
            deck.RemoveAt(0);
        }
        else
        {
            ShuffleDiscardPileIntoDeck();
            DrawCard();
        }
    }
    
    public void ShuffleDiscardPileIntoDeck()
    {
        deck.AddRange(discardPile);
        discardPile.Clear();
        ShuffleDeck();
    }
    
    public void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }
    
    
    
    
}
