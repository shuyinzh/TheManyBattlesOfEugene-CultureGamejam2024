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
    Vector3 firstCardPosition = new Vector3(-6.25f, 1.5f, 1);
    public DeckSystem deckSystem;
    public DeckType deckType;

    private float cardsInOneRow = 6f;

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
            GameObject o = Instantiate(cards[i], firstCardPosition + new Vector3((i % cardsInOneRow) * 2.5f, (float) Math.Floor(i/cardsInOneRow) * -3.5f, 0), Quaternion.identity, transform);
            o.GetComponent<SpriteRenderer>().sortingLayerName = "Overlay";
            o.transform.Find("Artwork").GetComponent<SpriteRenderer>().sortingLayerName = "Overlay";
            o.transform.Find("Canvas").GetComponent<Canvas>().overrideSorting = true;
            o.transform.Find("Canvas").GetComponent<Canvas>().sortingLayerName = "Overlay";
        }
        
    }
    void Update()
    {
        
    }
}
