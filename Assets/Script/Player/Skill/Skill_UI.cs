using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_UI : MonoBehaviour
{
    [SerializeField] AttackSystem attackSystem;
    [SerializeField] Skill_List skillList;
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
            else
            {
                targetSkill.GetComponent<SkillManager>().current_key = "";
            }
        }

        foreach (var targetSkill in skillList.skill_list)
        {
            if (attackSystem.currentWeapon_Lefthand == targetSkill.GetComponent<SkillManager>().targetWeapon && attackSystem.currentWeapon_Righthand == targetSkill.GetComponent<SkillManager>().targetWeapon)
            {
                targetSkill.GetComponent<SkillManager>().current_key = "Q";
            }
            else if (attackSystem.currentWeapon_Righthand == targetSkill.GetComponent<SkillManager>().targetWeapon)
            {
                targetSkill.GetComponent<SkillManager>().current_key = "E";
            }
            else
            {
                targetSkill.GetComponent<SkillManager>().current_key = "";
            }
        }
    }
}
