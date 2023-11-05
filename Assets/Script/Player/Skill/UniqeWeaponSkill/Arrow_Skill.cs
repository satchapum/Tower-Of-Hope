using UnityEngine;

public class Arrow_Skill : SkillManager
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

    [SerializeField] GameObject Arrow;
    [SerializeField] Transform ArrowPositon_1;
    [SerializeField] Transform ArrowPositon_2;
    [SerializeField] Transform ArrowPositon_3;

    public override void CreateSkill()
    {
        Debug.Log("Arrow skill");
        GameObject Arrow_1 = Instantiate(Arrow, ArrowPositon_1.position, ArrowPositon_1.transform.rotation);
        GameObject Arrow_2 = Instantiate(Arrow, ArrowPositon_2.position, ArrowPositon_2.transform.rotation);
        GameObject Arrow_3 = Instantiate(Arrow, ArrowPositon_3.position, ArrowPositon_3.transform.rotation);

        Arrow_1.SetActive(true);
        Arrow_2.SetActive(true);
        Arrow_3.SetActive(true);
    }
}
