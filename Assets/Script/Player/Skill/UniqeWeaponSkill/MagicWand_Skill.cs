using UnityEngine;
using System.Collections;

public class MagicWand_Skill : SkillManager
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
    [SerializeField] float skillEffectTime;
    [SerializeField] GameObject fireEffect;
    [SerializeField] public int damage;
    private void Awake()
    {
        CoolDownTime = skillData.CoolDownTime;
        ManaCost = skillData.manaCost;
        damage = skillData.damage;
    }
    public override void CreateSkill()
    {
        StartCoroutine(SkillTime());
    }
    IEnumerator SkillTime()
    {
        GameObject laserbeamCreate = Instantiate(fireEffect, AttackPosition.position, AttackPosition.transform.rotation);
        AudioManager.Instance.magicWand_Sound_SFX();
        laserbeamCreate.SetActive(true);
        yield return new WaitForSeconds(skillEffectTime);
        Destroy(laserbeamCreate);

    }
}
