using System;
using UnityEngine;

public class Player_health : Singleton<Player_health>
{
    [SerializeField] int maxHealth;

    public event Action<int, int> onHealthChange;

    void Start()
    {
        maxHealth = GameManager.Instance.playerBaseHealth;
        RefreshHealth();
    }

    public void WhenLevelUp()
    {
        maxHealth = GameManager.Instance.playerBaseHealth;
        GameManager.Instance.currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (GameManager.Instance.currentHealth <= 0)
            return;

        GameManager.Instance.currentHealth -= damage;
        RefreshHealth();

        if (GameManager.Instance.currentHealth <= 0)
            playerDie();
    }

    public void healPlayerHealt(int numberOfHeal)
    {
        GameManager.Instance.currentHealth += numberOfHeal;
        RefreshHealth();
    }

    public void RefreshHealth()
    {
        onHealthChange?.Invoke(GameManager.Instance.currentHealth, maxHealth);
    }

    void playerDie()
    {
        GameManager.Instance.ResetData();
        Destroy(gameObject);
    }
}
