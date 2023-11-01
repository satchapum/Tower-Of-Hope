using System;
using System.Collections;
using UnityEngine;

public class Player_Mana : Singleton<Player_Mana>
{
    [SerializeField] int maxMana;

    public event Action<int, int> onManaChange;

    void Start()
    {
        maxMana = GameManager.Instance.playerBaseMana;
        GameManager.Instance.currentMana = maxMana;
        RefreshMana();
    }
    public void WhenLevelUp()
    {
        maxMana = GameManager.Instance.playerBaseMana;
        GameManager.Instance.currentMana = maxMana;
    }

    public void TakeMana(int manaDrain)
    {
        if (GameManager.Instance.currentMana <= 0)
            return;

        GameManager.Instance.currentMana -= manaDrain;
        RefreshMana();
    }

    public void RePlayerMana(int numberOfReMana)
    {
        GameManager.Instance.currentMana += numberOfReMana;
        if (GameManager.Instance.currentMana > maxMana)
        {
            GameManager.Instance.currentMana = maxMana;
        }
        RefreshMana();

    }

    public void DrainPlayerMana(int numberOfUsesMana)
    {
        GameManager.Instance.currentMana -= numberOfUsesMana;
        RefreshMana();
    }

    public void RefreshMana()
    {
        onManaChange?.Invoke(GameManager.Instance.currentMana, maxMana);
    }
}
