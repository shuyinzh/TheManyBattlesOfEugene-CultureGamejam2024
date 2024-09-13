using UnityEngine;

public class Player: MonoBehaviour
{
    public DeckSystem deckSystem;
    
    void Start()
    {
        deckSystem = GetComponent<DeckSystem>();
    }

    void StartMatch()
    {
        deckSystem.StartMatch();
    }

}