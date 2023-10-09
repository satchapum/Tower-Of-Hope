using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_UI : MonoBehaviour
{
    [SerializeField] AttackSystem attackSystem;
    [SerializeField] Skill_List skillList;

    [Header("MergeSkill")]
    [SerializeField] SkillManager skillSwordSword_1;
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
        SwordSwordSkill();
        //AddSkillHereAndCreateFunction
    }

    void SwordSwordSkill()
    {
        if (attackSystem.currentWeapon_Lefthand == "Sword" && attackSystem.currentWeapon_Righthand == "Sword")
        {
            skillSwordSword_1.current_key = "X";
        }
        else
        {
            skillSwordSword_1.current_key = "";
        }
    }
}
