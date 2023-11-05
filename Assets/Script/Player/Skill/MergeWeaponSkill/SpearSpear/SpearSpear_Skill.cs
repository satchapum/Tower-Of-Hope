using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpear_Skill : SkillManager
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
    [SerializeField] public int damage;
    [SerializeField] public float timeToDestroy;
    [SerializeField] float backWardTime;
    [SerializeField] GameObject Spear;

    public override void CreateSkill()
    {
        Debug.Log("DaggerDagger Skill");
        StartCoroutine(DoTimeBackward());
        CreateSpear();
    }

    void CreateSpear()
    {
        GameObject create_Arrow = Instantiate(Spear, AttackPosition.position, AttackPosition.transform.rotation);
        create_Arrow.SetActive(true);
    }

    IEnumerator DoTimeBackward()
    {
        Player_Movement.Instance.tr.emitting = true;
        Player_Movement.Instance.isBackWardDash = true;
        yield return new WaitForSeconds(backWardTime);
        Player_Movement.Instance.isBackWardDash = false;
        Player_Movement.Instance.tr.emitting = false;
    }
}
