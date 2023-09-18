using System;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    public int CurrentHealth => currentHealth;
    [SerializeField] int currentHealth;

    [SerializeField] GameObject player;
    [SerializeField] GameObject thisMonsterObject;
    [SerializeField] MonsterBehavior monsterBehavior;

    [SerializeField] GameObject attackArea;

    public event Action<int, int> onHealthChange;

    void monsterDie()
    {
        monsterBehavior.WhenMonsterDestroy();
        Destroy(thisMonsterObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != attackArea)
            return;

        //featureAddAnotherWeapondamage
        TakeDamage(1);
    }

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
            monsterDie();
    }

    void RefreshHealth()
    {
        onHealthChange?.Invoke(currentHealth, maxHealth);
    }
}
