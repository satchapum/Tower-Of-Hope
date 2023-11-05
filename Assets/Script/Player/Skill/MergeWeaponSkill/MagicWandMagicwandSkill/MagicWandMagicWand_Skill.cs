using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWandMagicWand_Skill : SkillManager
{
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
    [SerializeField] float skillEffectTime;
    [SerializeField] GameObject LaserForCreate;
    [SerializeField] public int damage;

    public override void CreateSkill()
    {
        Debug.Log("MagicWand skill");
        StartCoroutine(SkillTime());
    }
    IEnumerator SkillTime()
    {
        GameObject laserbeamCreate = Instantiate(LaserForCreate, AttackPosition, false);
        laserbeamCreate.SetActive(true);
        yield return new WaitForSeconds(skillEffectTime);
        Destroy(laserbeamCreate);

    }
}
