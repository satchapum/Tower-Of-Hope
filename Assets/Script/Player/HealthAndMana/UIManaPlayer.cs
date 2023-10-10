using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIManaPlayer : MonoBehaviour
{
    Player_Mana Mana;

    void Awake()
    {
        Mana = FindObjectOfType<Player_Mana>();
        if (Mana != null)
            Mana.onManaChange += SetMana;
    }

    void OnDestroy()
    {
        Mana.onManaChange -= SetMana;
    }

    public abstract void SetMana(int currentMana, int maxMana);
}
