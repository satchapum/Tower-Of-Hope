using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSword_Skill : SkillManager
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
    [SerializeField] float whenSpawnDelay;
    [SerializeField] GameObject swordForCreate;
    [SerializeField] public int damage;

    private void Awake()
    {
        CoolDownTime = skillData.CoolDownTime;
        ManaCost = skillData.manaCost;
        damage = skillData.damage;
    }

    public override void CreateSkill()
    {
        Debug.Log("SwordSword skill");
        StartCoroutine(SkillTime());
    }
    IEnumerator SkillTime()
    {
        GameObject swordForRotate = Instantiate(swordForCreate, AttackPosition.transform.position, AttackPosition.transform.rotation);
        swordForRotate.transform.parent = AttackPosition.transform;
        swordForRotate.SetActive(true);
        swordForRotate.GetComponent<RotateSword>().enabled = false;
        yield return new WaitForSeconds(whenSpawnDelay);
        swordForRotate.GetComponent<RotateSword>().enabled = true;
        AudioManager.Instance.swordSword_Sound_SFX();
        yield return new WaitForSeconds(skillEffectTime);
        Destroy(swordForRotate);
    }
}
