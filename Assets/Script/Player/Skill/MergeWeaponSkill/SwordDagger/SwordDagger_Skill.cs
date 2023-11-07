using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDagger_Skill : SkillManager
{
    [SerializeField] SkillSO skillData;
    public override Transform attackPositon { get { return AttackPosition; } set { AttackPosition = value; } }
    public override string current_key { get { return Current_key; } set { Current_key = value; } }
    public override int coolDownTime { get { return CoolDownTime; } set { CoolDownTime = value; } }

    public override Sprite skill_Icon { get { return Skill_Icon; } set { Skill_Icon = value; } }

    public override string targetWeapon { get { return TargetWeapon; } set { TargetWeapon = value; } }

    public override int manaCost { get { return ManaCost; } set { ManaCost = value; } }

    [SerializeField] Sprite Skill_Icon;
    [SerializeField] string Current_key;
    [SerializeField] Transform AttackPosition;
    [SerializeField] int CoolDownTime;
    [SerializeField] int ManaCost;
    [SerializeField] string TargetWeapon;
    [SerializeField] int damage;
    [SerializeField] int percentOfSpeedIncrease;
    [SerializeField] float buffTime;
    [SerializeField] Sword sword;
    [SerializeField] Dagger dagger;

    private void Awake()
    {
        CoolDownTime = skillData.CoolDownTime;
        ManaCost = skillData.manaCost;
        damage = skillData.damage;
    }
    public override void CreateSkill()
    {
        
        Debug.Log("SwordDagger Skill ");
        StartCoroutine(DoSkill());
    }
    IEnumerator DoSkill()
    {
        float attackCooldownSwordTemp = sword.attackCooldown;
        float attackCooldownDaggerTemp = dagger.attackCooldown;
        sword.attackCooldown = sword.attackCooldown  - ((sword.attackCooldown * percentOfSpeedIncrease) / 100);
        dagger.attackCooldown = dagger.attackCooldown - ((dagger.attackCooldown * percentOfSpeedIncrease) / 100);
        yield return new WaitForSeconds(buffTime);
        sword.attackCooldown = attackCooldownSwordTemp;
        dagger.attackCooldown = attackCooldownDaggerTemp;
    }
}
