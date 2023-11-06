using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerDoDamage : MonoBehaviour
{
    [SerializeField] MagicWandDagger_Skill skill;
    [SerializeField] int daggerSpeed;
    [SerializeField] Rigidbody2D rb;
    Transform targetPos;

    private void Update()
    {
        if (FindAnyObjectByType<Monster>())
        {
            var target = FindAnyObjectByType<Monster>().GetComponent<Transform>();
            targetPos = target;
            DaggerFollowMonster();
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var monster in GameObject.FindObjectsOfType<Monster>())
        {
            if (collision.gameObject == monster.gameObject)
            {
                collision.gameObject.GetComponent<MonsterHealth>().TakeDamage(skill.damage);
                Destroy(gameObject);
            }
        }
    }
    void DaggerFollowMonster()
    {
        Vector3 positionOfMonster = Vector3.MoveTowards(transform.position, targetPos.position, daggerSpeed * Time.deltaTime);
        rb.MovePosition(positionOfMonster);

        Vector3 lookAt = transform.InverseTransformPoint(targetPos.position);
        float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0, 0, angle);
    }
}
