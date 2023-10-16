using System;
using UnityEngine;

public class Player_health : Singleton<Player_health>
{
    [SerializeField] int maxHealth;
    public int CurrentHealth => currentHealth;
    [SerializeField] int currentHealth;

    public event Action<int, int> onHealthChange;

    void Start()
    {
        maxHealth = GameManager.Instance.playerBaseHealth;
        currentHealth = maxHealth;
        RefreshHealth();
    }

    public void WhenLevelUp()
    {
        maxHealth = GameManager.Instance.playerBaseHealth;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
            return;

        currentHealth -= damage;
        RefreshHealth();

        if (currentHealth <= 0)
            playerDie();
    }

    public void healPlayerHealt(int numberOfHeal)
    {
        currentHealth += numberOfHeal;
        RefreshHealth();
    }

    public void RefreshHealth()
    {
        onHealthChange?.Invoke(currentHealth, maxHealth);
    }

    void playerDie()
    {
        Destroy(gameObject);
    }
}
