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

        StartCoroutine(makeIconsFlash());
    }

    private IEnumerator makeIconsFlash()
    {
        Color standardColour = new Color(164, 164, 164, 157);
        Vector3 oldScaleIdle = idleIcon.transform.localScale;
        Vector3 oldScaleAttack = attackIcon.transform.localScale;
        Vector3 oldScaleDefense = defenseIcon.transform.localScale;
        idleIcon.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        idleIcon.GetComponent<SpriteRenderer>().color = Color.white;
        attackIcon.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        attackIcon.GetComponent<SpriteRenderer>().color = Color.red;
        defenseIcon.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        defenseIcon.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(0.3f);
        idleIcon.transform.localScale = oldScaleIdle;
        idleIcon.GetComponent<SpriteRenderer>().color = standardColour;
        attackIcon.transform.localScale = oldScaleAttack;
        attackIcon.GetComponent<SpriteRenderer>().color = standardColour;
        defenseIcon.transform.localScale = oldScaleDefense;
        defenseIcon.GetComponent<SpriteRenderer>().color = standardColour;
    }
}