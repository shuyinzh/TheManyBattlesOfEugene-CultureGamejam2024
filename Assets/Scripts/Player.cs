using UnityEngine;

public class Player: MonoBehaviour
{
    public DeckSystem deckSystem;
    
    public int BaseZeitgeist = 3;
    public int AdditionalZeitgeist = 0;
    public int Zeitgeist = 0;
    
    public double ZeitgeistModifier = 1.0;
    
    
    void Start()
    {
        deckSystem = GetComponent<DeckSystem>();
    }

    public void StartMatch()
    {
        deckSystem.StartMatch();
        Zeitgeist = BaseZeitgeist;
    }

}