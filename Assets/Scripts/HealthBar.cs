using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Battler battler;
    public Transform healthBar;
    private int currentHealth;
    private int maxHealth;
    private float maxSize;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = battler.Health.maxHP;
        currentHealth = battler.Health.currentHP;
        maxSize = healthBar.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = battler.Health.currentHP;
        healthBar.transform.localScale = new Vector3(maxSize * currentHealth / maxHealth,
            healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}