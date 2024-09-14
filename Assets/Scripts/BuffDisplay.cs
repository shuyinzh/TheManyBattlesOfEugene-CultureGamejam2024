using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuffDisplay : MonoBehaviour
{
    public Battler battler;
    public TMP_Text attack;
    public TMP_Text defense;
    // Start is called before the first frame update
    void Start()
    {
        attack.text = "";
        defense.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        attack.text = "+" + battler.AdditionalAttack + (battler.AttackModifier > 1.0 ? ("*" + (int)battler.AttackModifier) : "");
        defense.text = battler.Defense.ToString(); 
    }
}
