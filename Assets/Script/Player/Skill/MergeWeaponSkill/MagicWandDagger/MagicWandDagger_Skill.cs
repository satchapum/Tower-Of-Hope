using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWandDagger_Skill : SkillManager
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
    [SerializeField] public int damage;
    [SerializeField] int numberToCreate;
    [SerializeField] float timeToCreate;
    [SerializeField] GameObject daggerForCreate;

    private void Awake()
    {
        CoolDownTime = skillData.CoolDownTime;
        ManaCost = skillData.manaCost;
        damage = skillData.damage;
    }
    public override void CreateSkill()
    {
        Debug.Log("MagicWandDagger skill");
        StartCoroutine(CreateDelay());
    }

    IEnumerator CreateDelay()
    {
        for (int currentNumberOfDaggerCreate = 0; currentNumberOfDaggerCreate < numberToCreate; currentNumberOfDaggerCreate++)
        {
            CreateDagger();
            yield return new WaitForSeconds(timeToCreate);
        }
    }
    void CreateDagger()
    {
        AudioManager.Instance.magicWandDagger_Sound_SFX();
        GameObject create_Arrow = Instantiate(daggerForCreate, AttackPosition.position, AttackPosition.transform.rotation);
        create_Arrow.SetActive(true);
    }
}
