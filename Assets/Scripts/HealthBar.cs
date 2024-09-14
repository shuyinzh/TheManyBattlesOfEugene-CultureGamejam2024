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
    public GameObject defenseIcon;
    public GameObject attackIcon;
    public GameObject idleIcon;

    // Start is called before the first frame update
    void Start()
    {
        defenseIcon.SetActive(false);
        attackIcon.SetActive(false);
        maxHealth = battler.Health.maxHP;
        currentHealth = battler.Health.currentHP;
        maxSize = healthBar.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        updateHealth();
    }

    public void updateHealth()
    {
        currentHealth = battler.Health.currentHP;
        healthBar.transform.localScale = new Vector3(maxSize * currentHealth / maxHealth,
            healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void updateIntent()
    {
        switch (battler.CurrentIntent)
        {
            case Intent.Attack:
                idleIcon.SetActive(false);
                defenseIcon.SetActive(false);
                attackIcon.SetActive(true);
                break;
            case Intent.Defend:
                idleIcon.SetActive(false);
                attackIcon.SetActive(false);
                defenseIcon.SetActive(true);
                break;
            default:
                attackIcon.SetActive(false);
                defenseIcon.SetActive(false);
                idleIcon.SetActive(true);
                break;
        }
    }
}