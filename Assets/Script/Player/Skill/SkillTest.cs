using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTest : SkillManager
{
    public override Transform attackPositon { get; set; }
    public override string current_key { get; set; }
    public override int coolDownTime { get; set ; }

    [SerializeField] string Current_key;
    [SerializeField] Transform AttackPosition;
    [SerializeField] int CoolDownTime;
    private void Start()
    {
        current_key = Current_key;
        attackPositon = AttackPosition;
        coolDownTime = CoolDownTime;
    }

    public override void CreateSkill()
    {
        Debug.Log("Skill kill");
    }
}
