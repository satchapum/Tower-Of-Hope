using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMagicWand_Skill : SkillManager
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
    [SerializeField] GameObject swordForCreate;
    [SerializeField] Transform attackPosition_1;
    [SerializeField] Transform attackPosition_2;
    [SerializeField] Transform attackPosition_3;
    [SerializeField] Transform attackPosition_4;
    [SerializeField] public int damage;
    public override void CreateSkill()
    {
        Debug.Log("SwordMagicWand skill");
        StartCoroutine(SkillTime());
    }
    IEnumerator SkillTime()
    {
        GameObject swordForRotate_1 = Instantiate(swordForCreate, attackPosition_1.transform.position, attackPosition_1.transform.rotation);
        swordForRotate_1.SetActive(true);
        GameObject swordForRotate_2 = Instantiate(swordForCreate, attackPosition_2.transform.position, attackPosition_2.transform.rotation);
        swordForRotate_2.SetActive(true);
        GameObject swordForRotate_3 = Instantiate(swordForCreate, attackPosition_3.transform.position, attackPosition_3.transform.rotation);
        swordForRotate_3.SetActive(true);
        GameObject swordForRotate_4 = Instantiate(swordForCreate, attackPosition_4.transform.position, attackPosition_4.transform.rotation);
        swordForRotate_4.SetActive(true);
        swordForRotate_1.transform.parent = AttackPosition;
        swordForRotate_2.transform.parent = AttackPosition;
        swordForRotate_3.transform.parent = AttackPosition;
        swordForRotate_4.transform.parent = AttackPosition;

        yield return new WaitForSeconds(skillEffectTime);
        Destroy(swordForRotate_1);
        Destroy(swordForRotate_2);
        Destroy(swordForRotate_3);
        Destroy(swordForRotate_4);
    }
}
