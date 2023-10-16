using System;
using System.Collections;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int CurrentHealth => currentHealth;
    [SerializeField] int currentHealth;

    [SerializeField] GameObject player;
    [SerializeField] GameObject thisMonsterObject;
    [SerializeField] MonsterBehavior monsterBehavior;

    void monsterDie()
    {
        monsterBehavior.WhenMonsterDestroy();
        GameManager.Instance.currentMonsterCount = GameManager.Instance.currentMonsterCount - 1;
        if (GameManager.Instance.currentMonsterCount == 0)
        {
            ItemDrop.Instance.dropItem(gameObject.transform);
        }
        Destroy(thisMonsterObject);
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
            return;

        currentHealth -= damage;

        if (currentHealth <= 0)
            monsterDie();
    }


}
