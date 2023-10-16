using UnityEngine;
using UnityEngine.UI;
public class UILevel_Slider : UILevelPlayer
{
    [SerializeField] Slider levelExperienceSlider;

    public override void SetPlayerLevelExperience(int currenLevelExperience, int maxPlayerLevelExperiencePerLevel)
    {
        levelExperienceSlider.value =  currenLevelExperience / (float)maxPlayerLevelExperiencePerLevel;
    }
}
