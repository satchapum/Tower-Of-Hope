using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIHealthMonster : MonoBehaviour
{
    MonsterHealth health;

    void Awake()
    {
        health = FindObjectOfType<MonsterHealth>();
        if (health != null)
            health.onHealthChange += SetHealth;
    }

    void OnDestroy()
    {
        health.onHealthChange -= SetHealth;
    }

    public abstract void SetHealth(int currentHealth, int maxHealth);
}
