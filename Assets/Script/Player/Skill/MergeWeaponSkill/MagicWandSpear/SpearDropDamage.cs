using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearDropDamage : MonoBehaviour
{
    [SerializeField] GameObject spearForCreate;
    [SerializeField] MagicWandSpear_Skill skill;
    [SerializeField] SpearDrop spearDrop;
    [SerializeField] GameObject spear;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == spear)
        {
            Destroy(spearForCreate);
        }
        foreach (var monster in GameObject.FindObjectsOfType<Monster>())
        {
            if (collision.gameObject == monster.gameObject)
            {
                collision.gameObject.GetComponent<MonsterHealth>().TakeDamage(skill.damage);
            }
        }
    }
}
