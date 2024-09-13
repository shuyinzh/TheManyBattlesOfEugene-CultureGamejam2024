using System.Collections.Generic;

public class Effect
{
    public string Name;

    public string Description;

    public List<EffectType> Types;
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
        }
    };

    public static Effect Sleep = new()
    {
        Name = "Sleep",
        Description = "The target is asleep.",
        Types = new List<EffectType>()
        {
            EffectType.Sleep
        }
    };

    public static Effect Attack = new()
    {
        Name = "Attack",
        Description = "The target is attacked.",
        Types = new List<EffectType>()
        {
            EffectType.Attack
        }
    };

    public static Effect Heal = new()
    {
        Name = "Heal",
        Description = "The target is healed.",
        Types = new List<EffectType>()
        {
            EffectType.Heal
        }
    };

    public static Effect Taunt = new()
    {
        Name = "Taunt",
        Description = "The target is taunted.",
        Types = new List<EffectType>()
        {
            EffectType.Taunt
        }
    };
    public static Effect Defense = new()
    {
        Name = "Defense",
        Description = "The target is defended.",
        Types = new List<EffectType>()
        {
            EffectType.Defense
        }
    };
    public static Effect Sublime = new()
    {
        Name = "Sublime",
        Description = "The target is sublimed.",
        Types = new List<EffectType>()
        {
            EffectType.Sublime
        }
    };
}