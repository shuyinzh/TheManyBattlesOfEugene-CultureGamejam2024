using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Health health;

    void Start()
    {
        health = GetComponent<Health>();
    }

    void StartMatch()
    {
        health.Reset();
    }

    void Update()
    {
        if (!health.IsAlive)
        {
            Debug.Log("Enemy is dead!");
        }
    }
}