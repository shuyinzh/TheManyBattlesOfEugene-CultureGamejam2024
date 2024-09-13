using System.Collections.Generic;
using UnityEngine;

public abstract class Battler : MonoBehaviour
{
    public Health Health;
    public string Name;
    public List<Effect> Effects {get; private set;}
    public void Start()
    {
        Health = GetComponent<Health>();
        Effects = new();
    }

    public void StartMatch()
    {
        Health.Reset();
        RemoveEffects();
    }

    public void addEffect(Effect effect)
    {
        Effects.Add(effect);
    }
    public void addEffects(List<Effect> effects)
    {
        Effects.AddRange(effects);
    }

    public void applyEffects()
    {
        foreach (var effect in Effects)
        {
            // effect.Apply(this);
        }
    }

    public void RemoveEffects()
    {
        Effects.Clear();
    }

    public void Update()
    {
        if (!Health.IsAlive)
        {
            Debug.Log($"{name} is dead!");
        }
    }
}