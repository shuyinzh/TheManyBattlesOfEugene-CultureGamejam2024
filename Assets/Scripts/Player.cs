using UnityEngine;

public class Player: Battler
{
    public DeckSystem deckSystem;
    
    void Start()
    {
        base.Start();
        deckSystem = GetComponent<DeckSystem>();
    }

    void StartMatch()
    {
        base.StartMatch();
        deckSystem.StartMatch();
    }

}