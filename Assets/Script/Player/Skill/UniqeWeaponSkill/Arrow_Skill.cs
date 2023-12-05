using UnityEngine;

public class Arrow_Skill : SkillManager
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

    [SerializeField] GameObject Arrow;
    [SerializeField] Transform ArrowPositon_1;
    [SerializeField] Transform ArrowPositon_2;
    [SerializeField] Transform ArrowPositon_3;

    private void Awake()
    {
        CoolDownTime = skillData.CoolDownTime;
        ManaCost = skillData.manaCost;
        damage = skillData.damage;
    }

    public override void CreateSkill()
    {
        Debug.Log("Arrow skill");

        CreateArrow(ArrowPositon_1);
        CreateArrow(ArrowPositon_2);
        CreateArrow(ArrowPositon_3);
    }

    void CreateArrow(Transform ArrowPositon)
    {
        GameObject create_Arrow = Instantiate(Arrow, ArrowPositon.position, ArrowPositon.transform.rotation);
        AudioManager.Instance.arrow_Sound_SFX();
        create_Arrow.SetActive(true);
    }
}
