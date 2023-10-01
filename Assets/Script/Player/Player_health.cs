using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : Singleton<Player_health>
{
    [SerializeField] int maxHealth = 5;
    public int CurrentHealth => currentHealth;
    [SerializeField] int currentHealth;

    public event Action<int, int> onHealthChange;

    private IEnumerator coroutine;

    void Start()
    {
        currentHealth = maxHealth;
        RefreshHealth();
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

    void RefreshHealth()
    {
        onHealthChange?.Invoke(currentHealth, maxHealth);
    }

    void playerDie()
    {
        Destroy(gameObject);
    }
}
