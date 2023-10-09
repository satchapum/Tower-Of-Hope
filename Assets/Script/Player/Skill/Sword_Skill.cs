using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Skill : SkillManager
{
    public override Transform attackPositon { get{ return AttackPosition; } set{ AttackPosition = value; } }
    public override string current_key { get { return Current_key; } set { Current_key = value; } }
    public override int coolDownTime { get { return CoolDownTime; } set { CoolDownTime = value; } }

    public override Sprite skill_Icon { get { return Skill_Icon; } set { Skill_Icon = value; } }

    [SerializeField] Sprite Skill_Icon;
    [SerializeField] string Current_key;
    [SerializeField] Transform AttackPosition;
    [SerializeField] int CoolDownTime;

    public override void CreateSkill()
    {
        Debug.Log("Skill kill");
    }
}
