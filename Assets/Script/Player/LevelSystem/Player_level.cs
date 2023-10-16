using System;
using UnityEngine;

public class Player_level : Singleton<Player_level>
{
    [SerializeField] int maxPlayerLevelExperiencePerLevel = 100;
    public int CurrenLevelExperience => currenLevelExperience;
    [SerializeField] int currenLevelExperience;

    public event Action<int, int> onLevelExperienceChange;

    void Start()
    {
        RefreshHealth();
    }

    public void TakeDamage(int monsterExperience)
    {
        if (monsterExperience >= 100)
        {
            GameManager.Instance.currentplayerLevel += 1;
        }
        RefreshHealth();
    }

    void RefreshHealth()
    {
        onLevelExperienceChange?.Invoke(currenLevelExperience, maxPlayerLevelExperiencePerLevel);
    }
}
