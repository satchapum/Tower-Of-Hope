using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMagicWand_Skill : SkillManager
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
    [SerializeField] GameObject ArrowFrostCreate;
    [SerializeField] GameObject ArrowFireCreate;

    [SerializeField] List<GameObject> arrow_List;
    public List<Monster> all_Monster_List;
    private void Awake()
    {
        CoolDownTime = skillData.CoolDownTime;
        ManaCost = skillData.manaCost;
        damage = skillData.damage;
    }

    public override void CreateSkill()
    {
        Debug.Log("ArrowMagicWand Skill");
        StartCoroutine(CreateDelay());
    }
    IEnumerator CreateDelay()
    {
        for (int currentNumberOfDaggerCreate = 0; currentNumberOfDaggerCreate < numberToCreate; currentNumberOfDaggerCreate++)
        {
            int randomNUmber = Random.Range(0, 2);
            Debug.Log(randomNUmber);
            GameObject randomArrow = arrow_List[randomNUmber];
            AudioManager.Instance.arrowMagicWand_Sound_SFX();

            if (randomArrow == ArrowFrostCreate)
            {
                CreateArrow(ArrowFrostCreate, currentNumberOfDaggerCreate);
                yield return new WaitForSeconds(timeToCreate);
            }
            else if (randomArrow == ArrowFireCreate)
            {
                CreateArrow(ArrowFireCreate, currentNumberOfDaggerCreate);
                yield return new WaitForSeconds(timeToCreate);
            }
            
        }
    }
    void CreateArrow(GameObject arrowType, int numberOfMonster)
    {
        GameObject create_Arrow = Instantiate(arrowType, AttackPosition.position, AttackPosition.transform.rotation);
        if (numberOfMonster < all_Monster_List.Count)
        {
            if (arrowType == ArrowFrostCreate)
            {
                create_Arrow.SetActive(true);
                create_Arrow.GetComponent<ArrowFrost>().monsterTarget = all_Monster_List[numberOfMonster].gameObject;
            }
            else if (arrowType == ArrowFireCreate)
            {
                create_Arrow.SetActive(true);
                create_Arrow.GetComponent<ArrowFire>().monsterTarget = all_Monster_List[numberOfMonster].gameObject;
            }
        }
        
    }
}
