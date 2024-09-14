﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum Intent
{
    Attack,
    Defend,
    Idle
}

public abstract class Battler : MonoBehaviour
{
    public String characterName;
    public TauntGenerator TauntGenerator;
    public Health Health;
    public string Name;

    public int AdditionalDefenseOnDefense = 0;
    public int Defense = 0;

    public int BaseAttack = 1;
    public int AdditionalAttack = 0;
    public double AttackModifier = 1.0;

    public Intent CurrentIntent;

    //Indicates how many turns the battler is charmed for
    public int charmed = 0;
    public int RepeatAction = 1;

    public int sleep;

    public int taunted;
    
    public bool isTaunted => taunted > 0;

    public void Start()
    {
        Health = GetComponent<Health>();
    }

    public void StartMatch()
    {
        Health.Reset();
    }

    public void StartRound()
    {
        AdditionalAttack = 0;
        Defense = 0;
        AttackModifier = 1.0;
        if (CurrentIntent == Intent.Defend)
        {
            Defense += AdditionalDefenseOnDefense;
        }

        if (sleep > 0)
        {
            sleep--;
        }

        if (charmed > 0)
        {
            charmed--;
        }
        if(taunted > 0)
        {
            taunted = 0;
        }
        RepeatAction = 1;
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
        string currentIntent = "";
        if (sleep > 0)
        {
            CurrentIntent = Intent.Idle;
            return;
        }

        if (UnityEngine.Random.Range(0, 10) >= 4)
        {
            CurrentIntent = Intent.Defend;
            currentIntent = "defend";
        }
        else
        {
            CurrentIntent = Intent.Attack;
            currentIntent = "attack";
        }
        TauntGenerator.GenerateIntent(characterName, TauntGenerator.currentBattle.Battle1, currentIntent);
    }

    public void SwitchIntent()
    {
        var intent = CurrentIntent == Intent.Attack ? Intent.Defend : Intent.Attack;
        SwitchIntent(intent);
    }

    public void SwitchIntent(Intent intent)
    {
        CurrentIntent = intent;
    }

    // Return the amount of damage dealt
    public int Attack(Battler target)
    {
        var damage = CalculateDamage();
        var actualDamage = ReduceDamage(target, damage);
        target.TakeDamage(actualDamage);
        return actualDamage;
    }

    private int ReduceDamage(Battler target, int damage)
    {
        if (target.Defense >= damage)
        {
            target.Defense -= damage;
            return 0;
        }

        var remainingDamage = damage - target.Defense;
        target.Defense = 0;
        return remainingDamage;
    }

    public void TakeDamage(int damage)
    {
        Health.TakeDamage(damage);
    }

    public int CalculateDamage()
    {
        return (int)Math.Ceiling((BaseAttack + AdditionalAttack) * AttackModifier);
    }
}