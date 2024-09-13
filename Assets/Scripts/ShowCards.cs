using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum DeckType
{
    Deck,
    DiscardPile,
    Hand
}

public class ShowCards : MonoBehaviour
{
    Vector3 firstCardPosition = new Vector3(0, 0, 0);
    public DeckSystem deckSystem;
    public DeckType deckType;

    void Start()
    {
        List<Card> cards = new List<Card>();
        if (deckType == DeckType.Deck)
        {
            cards = deckSystem.Deck;
        }
        if (deckType == DeckType.DiscardPile)
        {
            cards = deckSystem.DiscardPile;
        }
        if (deckType == DeckType.Hand)
        {
            cards = deckSystem.Hand;
        }

        for (int i = 0; i < cards.Count; i++)
        {
            Debug.Log(cards[i].Name + ", position: " + (firstCardPosition + new Vector3((i % 7) * 20, (float) Math.Floor(i/7.0f) * 10, 0)));
            // TODO: use when prefabs available
            //Instantiate(cards[i], firstCardPosition + new Vector3((i % 7) * 20, (float) Math.Floor(i/7.0f) * 10, 0), Quaternion.identity);
        }
        
    }
    void Update()
    {
        
    }
}
