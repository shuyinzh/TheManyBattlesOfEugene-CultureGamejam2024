using UnityEngine;

public class Health: MonoBehaviour
{
    public int maxHP = 10;
    public int currentHP;
    public HealthBar healthBar;

    public bool IsAlive => currentHP > 0;
    public void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        Heal(-damage);
    }
    
    public void Heal(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
        healthBar.updateHealth();
    }

    public void UpdateIntent()
    {
        healthBar.updateIntent();
    }

    public void Die()
    {
        currentHP = 0;
    }

    public void Reset()
    {
        Start();
    }
}