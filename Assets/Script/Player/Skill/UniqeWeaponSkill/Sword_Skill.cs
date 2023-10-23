using UnityEngine;
using System.Collections;

public class Sword_Skill : SkillManager
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
    [SerializeField] int damageIncrese = 2;
    [SerializeField] float skillEffectTime;

    public override void CreateSkill()
    {
        Debug.Log("Create Sword Skill");
        StartCoroutine(SkillTime());
    }

    IEnumerator SkillTime()
    {
        var playerSetting = FindAnyObjectByType<GameManager>();
        var playerObject = FindAnyObjectByType<PlayerSetting>();
        int playerBeforeBuffDamage = playerSetting.playerBaseAttackDamage;
        playerObject.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        playerSetting.playerBaseAttackDamage = playerSetting.playerBaseAttackDamage + damageIncrese;
        yield return new WaitForSeconds(skillEffectTime);
        playerObject.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        playerSetting.playerBaseAttackDamage = playerBeforeBuffDamage;

    }
}
