using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UILevelPlayer : MonoBehaviour
{
    Player_level levelExperience;

    void Awake()
    {
        levelExperience = FindObjectOfType<Player_level>();
        if (levelExperience != null)
            levelExperience.onLevelExperienceChange += SetPlayerLevelExperience;
    }

    void OnDestroy()
    {
        levelExperience.onLevelExperienceChange -= SetPlayerLevelExperience;
    }

    public abstract void SetPlayerLevelExperience(int currenLevelExperience, int maxPlayerLevelExperiencePerLevel);
}
