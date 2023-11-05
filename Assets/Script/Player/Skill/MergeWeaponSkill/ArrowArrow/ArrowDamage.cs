using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamage : MonoBehaviour
{
    [SerializeField] ArrowArrow_Skill skill;
    [SerializeField] ArrowDrop arrowDrop;
    [SerializeField] GameObject arrow;
    [SerializeField] float timeDelayDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == arrow)
        {
            arrowDrop.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            StartCoroutine(DelayDestroy());
            return;
        }
        foreach (var monster in GameObject.FindObjectsOfType<Monster>())
        {
            if (collision.gameObject == monster.gameObject)
            {
                collision.gameObject.GetComponent<MonsterHealth>().TakeDamage(skill.damage);
                Destroy(gameObject);
            }
        }
    }
    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(timeDelayDestroy);
        Destroy(gameObject);
    }
}
