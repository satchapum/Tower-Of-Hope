using System;
using System.Collections;
using UnityEngine;

public class Player_Mana : Singleton<Player_Mana>
{
    [SerializeField] int maxMana;
    public int CurrentMana => currentMana;
    [SerializeField] int currentMana;

    public event Action<int, int> onManaChange;

    void Start()
    {
        maxMana = GameManager.Instance.playerBaseMana;
        currentMana = maxMana;
        RefreshMana();
    }
    public void WhenLevelUp()
    {
        maxMana = GameManager.Instance.playerBaseMana;
        currentMana = maxMana;
    }

    public void TakeMana(int manaDrain)
    {
        if (currentMana <= 0)
            return;

        currentMana -= manaDrain;
        RefreshMana();
    }

    public void RePlayerMana(int numberOfReMana)
    {
        currentMana += numberOfReMana;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        RefreshMana();

    }

    public void DrainPlayerMana(int numberOfUsesMana)
    {
        currentMana -= numberOfUsesMana;
        RefreshMana();
    }

    public void RefreshMana()
    {
        onManaChange?.Invoke(currentMana, maxMana);
    }
}
