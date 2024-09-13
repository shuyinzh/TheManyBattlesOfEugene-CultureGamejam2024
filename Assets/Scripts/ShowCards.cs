using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum DeckType
{
    DrawPile,
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
        List<GameObject> cards = new List<GameObject>();
        if (deckType == DeckType.DrawPile)
        {
            cards = deckSystem.DrawPile;
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
            Debug.Log(cards[i].name + ", position: " + (firstCardPosition + new Vector3((i % 7) * 20, (float) Math.Floor(i/7.0f) * 10, 0)));
            Instantiate(cards[i], firstCardPosition + new Vector3((i % 7) * 100, (float) Math.Floor(i/7.0f) * 50, 0), Quaternion.identity, transform);
        }
        
    }
    void Update()
    {
        
    }
}
