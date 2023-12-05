using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearDagger_Skill : SkillManager
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
    [SerializeField] float delayCreateDagger;
    [SerializeField] float delayImmute;
    [SerializeField] float moveSpeedWhenImmute;

    [SerializeField] GameObject DaggerForCreate;
    [SerializeField] GameObject player;
    [SerializeField] List<Transform> DaggerPosition;
    private void Awake()
    {
        CoolDownTime = skillData.CoolDownTime;
        ManaCost = skillData.manaCost;
        damage = skillData.damage;

    }

    public override void CreateSkill()
    {
        Debug.Log("SpearDagger Skill ");
        AudioManager.Instance.spearDagger_Sound_SFX();
        StartCoroutine(CreateDagger());
        
    }

    IEnumerator CreateDagger()
    {
        StartCoroutine(DoImmute());
        for (int currentNumberOfDagger = 0; currentNumberOfDagger < DaggerPosition.Count; currentNumberOfDagger++)
        {
            GameObject create_Arrow = Instantiate(DaggerForCreate, DaggerPosition[currentNumberOfDagger].position, DaggerPosition[currentNumberOfDagger].transform.rotation);
            create_Arrow.SetActive(true);
            yield return new WaitForSeconds(delayCreateDagger);
        }
        
    }
    IEnumerator DoImmute()
    {
        float speedTemp = player.GetComponent<Player_Movement>().moveSpeed;
        player.GetComponent<Player_Movement>().moveSpeed = moveSpeedWhenImmute;
        player.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(delayImmute);
        player.GetComponent<Collider2D>().enabled = true;
        player.GetComponent<Player_Movement>().moveSpeed = speedTemp;
    }
}
