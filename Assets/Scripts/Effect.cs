using System;
using System.Collections.Generic;

public class Effect
{
    public string Name;

    public string Description;

    public List<EffectType> Types;

    public double Value = 0;
    
    public int Duration = 1;

}


public enum EffectType
{
    Charm,
    Weaken,
    Sublime,
    Sleep,
    Attack,
    Heal,
    Taunt,
    Defense,
}

public class Effects
{
    public static Effect Charm = new()
    {
        Name = "Charm",
        Description = "The target is charmed.",
        Types = new List<EffectType>()
        {
            EffectType.Charm
        }
        
    };

    public static Effect Weaken = new()
    {
        Name = "Weaken",
        Description = "The target is weakened.",
        Types = new List<EffectType>()
        {
            EffectType.Weaken
        },
        Value=0.2 // 20% more damage
    };

    public static Effect Sleep = new()
    {
        Name = "Sleep",
        Description = "The target is asleep.",
        Types = new List<EffectType>()
        {
            EffectType.Sleep
        },
        Duration = 2// Max 2 turns
    };

    public static Effect Attack = new()
    {
        Name = "Attack",
        Description = "The target is attacked.",
        Types = new List<EffectType>()
        {
            EffectType.Attack
        },
        Value = 1
        
    };

    public static Effect Heal = new()
    {
        Name = "Heal",
        Description = "The target is healed.",
        Types = new List<EffectType>()
        {
            EffectType.Heal
        },
        Value = 1
    };

    public static Effect Taunt = new()
    {
        Name = "Taunt",
        Description = "The target is taunted.",
        Types = new List<EffectType>()
        {
            EffectType.Taunt
        },
        Value = 1
    };
    public static Effect Defense = new()
    {
        Name = "Defense",
        Description = "The target is defended.",
        Types = new List<EffectType>()
        {
            EffectType.Defense
        },
        Value = 1
        
    };
    public static Effect Sublime = new()
    {
        Name = "Sublime",
        Description = "The target is sublimed.",
        Types = new List<EffectType>()
        {
            EffectType.Sublime
        },
        Value = 2.0
    };
}