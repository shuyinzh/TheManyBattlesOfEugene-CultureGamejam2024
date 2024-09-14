using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuffDisplayMum : MonoBehaviour
{
    public Battler battler;
    public TMP_Text defense;
    // Start is called before the first frame update
    void Start()
    {
        defense.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        string lastDefense = defense.text;
        string newDefense = battler.Defense.ToString();

        defense.text = newDefense;
        if (!newDefense.Equals(lastDefense))
        {
            StartCoroutine(flashDefense());
        }
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
