using System;
using UnityEngine;
using TMPro;

public class Player_level : Singleton<Player_level>
{
    [SerializeField] int maxPlayerLevelExperiencePerLevel;

    [SerializeField] TMP_Text currentLevelShowText;

    public event Action<int, int> onLevelExperienceChange;

    [Header("Player upgrade stat per level")]
    [SerializeField] int amountBaseHealthUpgradePerLevel = 1;
    [SerializeField] int amountBaseManaUpgradePerLevel = 1;
    [SerializeField] int amountBaseAttackDamagePerLevel = 1;
    [SerializeField] int amountMaxIncreasePerLevel = 1;

    [SerializeField] int amountOflevelWhenLevelUp = 2;

    void Start()
    {
        currentLevelShowText.text = "Level : " + GameManager.Instance.currentplayerLevel;
        maxPlayerLevelExperiencePerLevel = GameManager.Instance.maxPlayerLevelExperiencePerLevel;
        RefreshLevelExperience();
    }

    public void GetLevelExperience(int monsterExperience)
    {
        GameManager.Instance.currentLevelExperience += monsterExperience;
        if (GameManager.Instance.currentLevelExperience >= maxPlayerLevelExperiencePerLevel)
        {
            GameManager.Instance.currentLevelExperience = 0;
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
        GameManager.Instance.maxPlayerLevelExperiencePerLevel += amountMaxIncreasePerLevel;

        Player_Mana.Instance.WhenLevelUp();
        Player_Mana.Instance.RefreshMana();
        Player_health.Instance.WhenLevelUp();
        Player_health.Instance.RefreshHealth();

        WhenLevelUp();
        RefreshLevelExperience();
    }

   void WhenLevelUp()
    {
        GameManager.Instance.maxPlayerLevelExperiencePerLevel = (GameManager.Instance.maxPlayerLevelExperiencePerLevel * amountOflevelWhenLevelUp) - (GameManager.Instance.maxPlayerLevelExperiencePerLevel / amountOflevelWhenLevelUp);
        maxPlayerLevelExperiencePerLevel = GameManager.Instance.maxPlayerLevelExperiencePerLevel;
        currentLevelShowText.text = "Level : " + GameManager.Instance.currentplayerLevel;
    }

    void RefreshLevelExperience()
    {
        onLevelExperienceChange?.Invoke(GameManager.Instance.currentLevelExperience, maxPlayerLevelExperiencePerLevel);
    }
}
