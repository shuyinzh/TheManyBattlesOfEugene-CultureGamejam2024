using System;
using System.Collections.Generic;
using UnityEngine;

public enum Intent
{
    Attack,
    Defend
}

public abstract class Battler : MonoBehaviour
{
    public Health Health;
    public string Name;
    public int Defense = 0;
    
    public int BaseAttack = 1;
    public int AdditionalAttack = 0;
    public double AttackModifier = 1.0;

    public Intent CurrentIntent;
    //Indicates how many turns the battler is charmed for
    public int charmed = 0;
    public int RepeatLastAction = 0;
    
    public int sleep;
    public void Start()
    {
        Health = GetComponent<Health>();
    }

    public void StartMatch()
    {
        Health.Reset();
        CreateRandomIntent();
        AdditionalAttack = 0;
        Defense = 0;
        AttackModifier = 1.0;
        
    }

    public void Update()
    {
        if (!Health.IsAlive)
        {
            Debug.Log($"{name} is dead!");
        }
    }

    public void CreateRandomIntent()
    {
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            CurrentIntent = Intent.Attack;
        }
        else
        {
            CurrentIntent = Intent.Defend;
        }
    }

    public void SwitchIntent()
    {
        if (CurrentIntent == Intent.Attack)
        {
            CurrentIntent = Intent.Defend;
        }
        else
        {
            CurrentIntent = Intent.Attack;
        }
    }
    
}