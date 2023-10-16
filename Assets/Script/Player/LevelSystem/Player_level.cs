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
        RefreshLevelExperience();
    }

    public void GetLevelExperience(int monsterExperience)
    {
        currenLevelExperience += monsterExperience;
        if (currenLevelExperience >= 100)
        {
            currenLevelExperience = currenLevelExperience - maxPlayerLevelExperiencePerLevel;
            GameManager.Instance.currentplayerLevel += 1;
        }
        RefreshLevelExperience();
    }

    void RefreshLevelExperience()
    {
        onLevelExperienceChange?.Invoke(currenLevelExperience, maxPlayerLevelExperiencePerLevel);
    }
}
