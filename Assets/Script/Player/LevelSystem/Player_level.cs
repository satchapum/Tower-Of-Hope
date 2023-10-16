using System;
using UnityEngine;

public class Player_level : Singleton<Player_level>
{
    [SerializeField] int maxPlayerLevelExperiencePerLevel;
    public int CurrenLevelExperience => currenLevelExperience;
    [SerializeField] int currenLevelExperience;

    public event Action<int, int> onLevelExperienceChange;

    [Header("Player upgrade stat per level")]
    [SerializeField] int amountBaseHealthUpgradePerLevel = 1;
    [SerializeField] int amountBaseManaUpgradePerLevel = 1;
    [SerializeField] int amountBaseAttackDamagePerLevel = 1;

    void Start()
    {
        maxPlayerLevelExperiencePerLevel = GameManager.Instance.maxPlayerLevelExperiencePerLevel;
        RefreshLevelExperience();
    }

    public void GetLevelExperience(int monsterExperience)
    {
        currenLevelExperience += monsterExperience;
        if (currenLevelExperience >= 100)
        {
            currenLevelExperience = currenLevelExperience - maxPlayerLevelExperiencePerLevel;
            DoLevelUp();
        }
        RefreshLevelExperience();
    }

    void DoLevelUp()
    {
        int numberOfUpgradeLevel = 1;

        GameManager.Instance.currentplayerLevel += numberOfUpgradeLevel;
        GameManager.Instance.playerBaseAttackDamage += amountBaseAttackDamagePerLevel;
        GameManager.Instance.playerBaseHealth += amountBaseHealthUpgradePerLevel;
        GameManager.Instance.playerBaseMana += amountBaseManaUpgradePerLevel;

        Player_Mana.Instance.WhenLevelUp();
        Player_Mana.Instance.RefreshMana();
        Player_health.Instance.WhenLevelUp();
        Player_health.Instance.RefreshHealth();

        maxPlayerLevelExperiencePerLevel = GameManager.Instance.maxPlayerLevelExperiencePerLevel;
        RefreshLevelExperience();
    }

    void RefreshLevelExperience()
    {
        onLevelExperienceChange?.Invoke(currenLevelExperience, maxPlayerLevelExperiencePerLevel);
    }
}
