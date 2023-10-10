using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_UI : MonoBehaviour
{
    [SerializeField] AttackSystem attackSystem;
    [SerializeField] Skill_List skillList;

    [Header("MergeSkill")]
    [SerializeField] SkillManager skillSwordSword;
    [SerializeField] SkillManager skillSwordArrow;
    [SerializeField] SkillManager skillSwordMagicWand;
    [SerializeField] SkillManager skillSwordSpear;
    [SerializeField] SkillManager skillSwordDagger;
    [SerializeField] SkillManager skillArrowArrow;
    [SerializeField] SkillManager skillArrowMagicWand;
    [SerializeField] SkillManager skillArrowSpear;
    [SerializeField] SkillManager skillArrowDagger;
    [SerializeField] SkillManager skillMagicWandMagicWand;
    [SerializeField] SkillManager skillMagicWandSpear;
    [SerializeField] SkillManager skillMagicWandDagger;
    [SerializeField] SkillManager skillSpearSpear;
    [SerializeField] SkillManager skillSpearDagger;
    [SerializeField] SkillManager skillDaggerDagger;
    private void Update()
    {
        foreach (var targetSkill in skillList.skill_list)
        {
            if (attackSystem.currentWeapon_Lefthand == targetSkill.GetComponent<SkillManager>().targetWeapon)
            {
                targetSkill.GetComponent<SkillManager>().current_key = "Q";
            }
            else if (attackSystem.currentWeapon_Righthand == targetSkill.GetComponent<SkillManager>().targetWeapon)
            {
                targetSkill.GetComponent<SkillManager>().current_key = "E";
            }
            else if(attackSystem.currentWeapon_Lefthand != targetSkill.GetComponent<SkillManager>().targetWeapon || attackSystem.currentWeapon_Righthand == targetSkill.GetComponent<SkillManager>().targetWeapon)
            {
                targetSkill.GetComponent<SkillManager>().current_key = "";
            }
        }

        SettingMergeSkill();
    }
    void SettingMergeSkill()
    {
        AllMergeSkill();
    }

    void AllMergeSkill()
    {
        if (attackSystem.currentWeapon_Lefthand == "Sword" && attackSystem.currentWeapon_Righthand == "Sword")
        {
            skillSwordSword.current_key = "X";
        }
        else
        {
            skillSwordSword.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "Sword" && attackSystem.currentWeapon_Righthand == "Arrow")
        {
            skillSwordArrow.current_key = "X";
        }
        else
        {
            skillSwordArrow.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "Sword" && attackSystem.currentWeapon_Righthand == "MagicWand")
        {
            skillSwordMagicWand.current_key = "X";
        }
        else
        {
            skillSwordMagicWand.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "Sword" && attackSystem.currentWeapon_Righthand == "Spear")
        {
            skillSwordSpear.current_key = "X";
        }
        else
        {
            skillSwordSpear.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "Sword" && attackSystem.currentWeapon_Righthand == "Dagger")
        {
            skillSwordDagger.current_key = "X";
        }
        else
        {
            skillSwordDagger.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "Arrow" && attackSystem.currentWeapon_Righthand == "Arrow")
        {
            skillArrowArrow.current_key = "X";
        }
        else
        {
            skillArrowArrow.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "Arrow" && attackSystem.currentWeapon_Righthand == "MagicWand")
        {
            skillArrowMagicWand.current_key = "X";
        }
        else
        {
            skillArrowMagicWand.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "Arrow" && attackSystem.currentWeapon_Righthand == "Spear")
        {
            skillArrowSpear.current_key = "X";
        }
        else
        {
            skillArrowSpear.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "Arrow" && attackSystem.currentWeapon_Righthand == "Dagger")
        {
            skillArrowDagger.current_key = "X";
        }
        else
        {
            skillArrowDagger.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "MagicWand" && attackSystem.currentWeapon_Righthand == "MagicWand")
        {
            skillMagicWandMagicWand.current_key = "X";
        }
        else
        {
            skillMagicWandMagicWand.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "MagicWand" && attackSystem.currentWeapon_Righthand == "Spear")
        {
            skillMagicWandSpear.current_key = "X";
        }
        else
        {
            skillMagicWandSpear.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "MagicWand" && attackSystem.currentWeapon_Righthand == "Dagger")
        {
            skillMagicWandDagger.current_key = "X";
        }
        else
        {
            skillMagicWandDagger.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "Spear" && attackSystem.currentWeapon_Righthand == "Spear")
        {
            skillSpearSpear.current_key = "X";
        }
        else
        {
            skillSpearSpear.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "Spear" && attackSystem.currentWeapon_Righthand == "Dagger")
        {
            skillSpearDagger.current_key = "X";
        }
        else
        {
            skillSpearDagger.current_key = "";
        }

        if (attackSystem.currentWeapon_Lefthand == "Dagger" && attackSystem.currentWeapon_Righthand == "Dagger")
        {
            skillDaggerDagger.current_key = "X";
        }
        else
        {
            skillDaggerDagger.current_key = "";
        }
    }
}
