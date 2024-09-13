using UnityEngine;

public class Player: MonoBehaviour
{
    public Health health;
    public DeckSystem deckSystem;
    
    void Start()
    {
        health = GetComponent<Health>();
        deckSystem = GetComponent<DeckSystem>();
    }

    void StartMatch()
    {
        health.Reset();
        deckSystem.StartMatch();
    }

    void Update()
    {
        if (!health.IsAlive)
        {
            Debug.Log("Player is dead!");
        }
    }
}