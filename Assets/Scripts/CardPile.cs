using TMPro;
using UnityEngine;

public class CardPile : MonoBehaviour
{
    
    public DeckSystem DeckSystem;
    public TMP_Text buttonText;
    public DeckTextType DeckTextType;

    private void Update()
    {
        if(DeckTextType == DeckTextType.DrawPile)
            buttonText.text = DeckSystem.DrawPile.Count.ToString();
        else if(DeckTextType == DeckTextType.DiscardPile)
            buttonText.text = DeckSystem.DiscardPile.Count.ToString();
    
    }
}

public enum DeckTextType
{
    DrawPile,
    DiscardPile,
}