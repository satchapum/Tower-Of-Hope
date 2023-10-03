using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Use : MonoBehaviour
{
    [Header("SkillCooldown")]
    [SerializeField] Image Q_image;
    [SerializeField] Image E_image;
    [SerializeField] Image X_image;
    [SerializeField] Image Z_image;

    [SerializeField] Skill_List skill;

    public bool IsKeyQ_Down = false;
    public bool IsKeyE_Down = false;
    public bool IsKeyX_Down = false;
    public bool IsKeyZ_Down = false;

    public float skillQCooldown = 0f;
    public float skillECooldown = 0f;
    public float skillXCooldown = 0f;
    public float skillZCooldown = 0f;

    private void Update()
    {
        if (InputManager.Instance.KeyQ_Down && IsKeyQ_Down == false)
        {
            useSkill("Q");
        }
        else if (InputManager.Instance.KeyE_Down && IsKeyE_Down == false) 
        {
            useSkill("E");
        }
        else if (InputManager.Instance.KeyX_Down && IsKeyX_Down == false)
        {
            useSkill("X");
        }
        else if (InputManager.Instance.KeyZ_Down && IsKeyZ_Down == false)
        {
            useSkill("Z");
        }
    }

    void useSkill(string keyName)
    {
        for (int orderInSkillList = 0; orderInSkillList < skill.skill_list.Count; orderInSkillList++)
        {
            var skilluse = skill.skill_list[orderInSkillList].GetComponent<SkillManager>();
            if (keyName == skilluse.current_key)
            {
                skilluse.CreateSkill();
                if (keyName == "Q")
                {
                    IsKeyQ_Down = true;
                }
                else if (keyName == "E")
                {
                    IsKeyE_Down = true;
                }
                else if (keyName == "Z")
                {
                    IsKeyZ_Down = true;
                }
                else if (keyName == "X")
                {
                    IsKeyX_Down = true;
                }
                StartCoroutine(attackLeftDelay(skilluse, keyName));
            }
        }
    }

    IEnumerator attackLeftDelay(SkillManager thisSkill, string keyName)
    {
        if (keyName == "Q")
        {
            while (skillQCooldown < thisSkill.coolDownTime)
            {
                Q_image.fillAmount = skillQCooldown/thisSkill.coolDownTime;
                skillQCooldown += Time.deltaTime;
                yield return null;
            }
            skillQCooldown = 0f;
            IsKeyQ_Down = false;
        }
        else if (keyName == "E")
        {
            while (skillECooldown < thisSkill.coolDownTime)
            {
                E_image.fillAmount = skillECooldown/thisSkill.coolDownTime;
                skillECooldown += Time.deltaTime;
                yield return null;
            }
            skillECooldown = 0f;
            IsKeyE_Down = false;
        }
        else if (keyName == "X")
        {
            while (skillXCooldown < thisSkill.coolDownTime)
            {
                X_image.fillAmount = skillQCooldown/thisSkill.coolDownTime;
                skillXCooldown += Time.deltaTime;
                yield return null;
            }
            skillXCooldown = 0f;
            IsKeyX_Down = false;
        }
        else if (keyName == "Z")
        {
            while (skillZCooldown < thisSkill.coolDownTime)
            {
                Z_image.fillAmount = skillQCooldown/thisSkill.coolDownTime;
                skillZCooldown += Time.deltaTime;
                yield return null;
            }
            skillZCooldown = 0f;
            IsKeyZ_Down = false;
        }

    }
}
