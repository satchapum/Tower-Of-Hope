using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicwandLaserBeam : MonoBehaviour
{
    [SerializeField] MagicWandMagicWand_Skill skill;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var monster in GameObject.FindObjectsOfType<Monster>())
        {
            if (collision.gameObject == monster.gameObject)
                collision.gameObject.GetComponent<MonsterHealth>().TakeDamage(skill.damage);

        }
    }
}
