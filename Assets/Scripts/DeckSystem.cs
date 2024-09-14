using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeckSystem : MonoBehaviour
{
    public List<GameObject> Deck;
    private const int MAX_HAND_SIZE = 5;
    private const int MIN_DECK_SIZE = 5;
    private const int MAX_DECK_SIZE = 10;
    
    
    public List<GameObject> DrawPile = new();
    public List<GameObject> Hand = new();
    public List<GameObject> DiscardPile = new();

    
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
            Debug.Log("" + drawnCard.name);
            DrawPile.RemoveAt(0);
            Debug.Log("Drawn card: " + drawnCard);
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
            if(DrawPile.Count == 0)
            {
                Debug.Log("No cards to draw");
            }
            else
            {
                DrawCards();
            }
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
            var temp = DrawPile[i];
            int randomIndex = Random.Range(i, DrawPile.Count);
            DrawPile[i] = DrawPile[randomIndex];
            DrawPile[randomIndex] = temp;
        }
    }
    
    
    public void PlayHandCard(int index)
    {
        if (index >= 0 && index < Hand.Count)
        {
            var card = Hand[index];
            Hand.RemoveAt(index);
            DiscardPile.Add(card);
        }
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
