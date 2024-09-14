using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCard : MonoBehaviour
{
    public int Cost = 1;
    public BattleManager battleManager;

    public abstract void whenPlayed();
}