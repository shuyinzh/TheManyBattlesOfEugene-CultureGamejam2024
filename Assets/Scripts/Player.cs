using UnityEngine;

public class Player: MonoBehaviour
{
    public DeckSystem deckSystem;
    
    void Start()
    {
        deckSystem = GetComponent<DeckSystem>();
    }

    public void StartMatch()
    {
        deckSystem.StartMatch();
    }

}