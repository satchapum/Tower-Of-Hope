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
            if (GameManager.Instance.currentWeapon_Lefthand == targetSkill.GetComponent<SkillManager>().targetWeapon)
            {
                targetSkill.GetComponent<SkillManager>().current_key = "Q";
            }
            else if (GameManager.Instance.currentWeapon_Righthand == targetSkill.GetComponent<SkillManager>().targetWeapon)
            {
                targetSkill.GetComponent<SkillManager>().current_key = "E";
            }
            else if(GameManager.Instance.currentWeapon_Lefthand != targetSkill.GetComponent<SkillManager>().targetWeapon || GameManager.Instance.currentWeapon_Righthand == targetSkill.GetComponent<SkillManager>().targetWeapon)
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
        if (GameManager.Instance.currentWeapon_Lefthand == "Sword" && GameManager.Instance.currentWeapon_Righthand == "Sword")
        {
            skillSwordSword.current_key = "X";
        }
        else
        {
            skillSwordSword.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "Sword" && GameManager.Instance.currentWeapon_Righthand == "Arrow" || GameManager.Instance.currentWeapon_Lefthand == "Arrow" && GameManager.Instance.currentWeapon_Righthand == "Sword")
        {
            skillSwordArrow.current_key = "X";
        }
        else
        {
            skillSwordArrow.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "Sword" && GameManager.Instance.currentWeapon_Righthand  == "MagicWand" || GameManager.Instance.currentWeapon_Lefthand == "MagicWand" && GameManager.Instance.currentWeapon_Righthand == "Sword")
        {
            skillSwordMagicWand.current_key = "X";
        }
        else
        {
            skillSwordMagicWand.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "Sword" && GameManager.Instance.currentWeapon_Righthand == "Spear" || GameManager.Instance.currentWeapon_Lefthand == "Spear" && GameManager.Instance.currentWeapon_Righthand == "Sword")
        {
            skillSwordSpear.current_key = "X";
        }
        else
        {
            skillSwordSpear.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "Sword" && GameManager.Instance.currentWeapon_Righthand == "Dagger" || GameManager.Instance.currentWeapon_Lefthand == "Dagger" && GameManager.Instance.currentWeapon_Righthand == "Sword")
        {
            skillSwordDagger.current_key = "X";
        }
        else
        {
            skillSwordDagger.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "Arrow" && GameManager.Instance.currentWeapon_Righthand == "Arrow")
        {
            skillArrowArrow.current_key = "X";
        }
        else
        {
            skillArrowArrow.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "Arrow" && GameManager.Instance.currentWeapon_Righthand == "MagicWand" || GameManager.Instance.currentWeapon_Lefthand == "MagicWand" && GameManager.Instance.currentWeapon_Righthand == "Arrow")
        {
            skillArrowMagicWand.current_key = "X";
        }
        else
        {
            skillArrowMagicWand.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "Arrow" && GameManager.Instance.currentWeapon_Righthand == "Spear" || GameManager.Instance.currentWeapon_Lefthand == "Spear" && GameManager.Instance.currentWeapon_Righthand == "Arrow")
        {
            skillArrowSpear.current_key = "X";
        }
        else
        {
            skillArrowSpear.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "Arrow" && GameManager.Instance.currentWeapon_Righthand == "Dagger" || GameManager.Instance.currentWeapon_Lefthand == "Dagger" && GameManager.Instance.currentWeapon_Righthand == "Arrow")
        {
            skillArrowDagger.current_key = "X";
        }
        else
        {
            skillArrowDagger.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "MagicWand" && GameManager.Instance.currentWeapon_Righthand == "MagicWand")
        {
            skillMagicWandMagicWand.current_key = "X";
        }
        else
        {
            skillMagicWandMagicWand.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "MagicWand" && GameManager.Instance.currentWeapon_Righthand == "Spear" || GameManager.Instance.currentWeapon_Lefthand == "Spear" && GameManager.Instance.currentWeapon_Righthand == "MagicWand")
        {
            skillMagicWandSpear.current_key = "X";
        }
        else
        {
            skillMagicWandSpear.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "MagicWand" && GameManager.Instance.currentWeapon_Righthand == "Dagger" || GameManager.Instance.currentWeapon_Lefthand == "Dagger" && GameManager.Instance.currentWeapon_Righthand == "MagicWand")
        {
            skillMagicWandDagger.current_key = "X";
        }
        else
        {
            skillMagicWandDagger.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "Spear" && GameManager.Instance.currentWeapon_Righthand == "Spear")
        {
            skillSpearSpear.current_key = "X";
        }
        else
        {
            skillSpearSpear.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "Spear" && GameManager.Instance.currentWeapon_Righthand == "Dagger" || GameManager.Instance.currentWeapon_Lefthand == "Dagger" && GameManager.Instance.currentWeapon_Righthand == "Spear")
        {
            skillSpearDagger.current_key = "X";
        }
        else
        {
            skillSpearDagger.current_key = "";
        }

        if (GameManager.Instance.currentWeapon_Lefthand == "Dagger" && GameManager.Instance.currentWeapon_Righthand == "Dagger")
        {
            skillDaggerDagger.current_key = "X";
        }
        else
        {
            skillDaggerDagger.current_key = "";
        }
    }
}
