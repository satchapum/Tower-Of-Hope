using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIHealthPlayer : MonoBehaviour
{
    Player_health health;

    void Awake()
    {
        health = FindObjectOfType<Player_health>();
        if (health != null)
            health.onHealthChange += SetHealth;
    }

    void OnDestroy()
    {
        health.onHealthChange -= SetHealth;
    }

    public abstract void SetHealth(int currentHealth, int maxHealth);
}
