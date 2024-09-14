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
        string lastAttack = attack.text;
        string lastDefense = defense.text;
        string newAttack = "+" + battler.AdditionalAttack + (battler.AttackModifier > 1.0 ? ("*" + (int)battler.AttackModifier) : "");
        string newDefense = battler.Defense.ToString();

        attack.text = newAttack;
        defense.text = newDefense;
        if (!newDefense.Equals(lastDefense))
        {
            StartCoroutine(flashDefense());
        }

        if (!newAttack.Equals(lastAttack))
        {
            StartCoroutine(flashAttack());
        }
    }

    private IEnumerator flashAttack()
    {
        Vector3 originalScale = attack.transform.localScale;
        attack.color = Color.red;
        attack.transform.localScale *= 3f;
        yield return new WaitForSeconds(0.3f);
        attack.transform.localScale = originalScale;
        attack.color = Color.white;
    }

    private IEnumerator flashDefense()
    {
        Vector3 originalScale = defense.transform.localScale;
        defense.color = Color.green;
        defense.transform.localScale *= 3f;
        yield return new WaitForSeconds(0.3f);
        defense.transform.localScale = originalScale;
        defense.color = Color.white;
    }
}
