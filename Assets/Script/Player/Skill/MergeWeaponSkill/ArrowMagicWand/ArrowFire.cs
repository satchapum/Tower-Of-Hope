using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFire : MonoBehaviour
{
    [SerializeField] ArrowMagicWand_Skill skill;
    [SerializeField] int daggerSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float delayTime;
    [SerializeField] int fireTime;
    [SerializeField] GameObject picture;
    public GameObject monsterTarget;

    private void Update()
    {
        if (monsterTarget)
        {
            ArrowFollowMonster();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == monsterTarget)
        {
            StartCoroutine(TakeDamageFire(monsterTarget));
            Destroy(picture);
        }
    }
    void ArrowFollowMonster()
    {
        Vector3 positionOfMonster = Vector3.MoveTowards(transform.position, monsterTarget.transform.position, daggerSpeed * Time.deltaTime);
        rb.MovePosition(positionOfMonster);

        Vector3 lookAt = transform.InverseTransformPoint(monsterTarget.transform.position);
        float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0, 0, angle);
    }
    IEnumerator TakeDamageFire(GameObject target)
    {
        for (int numberOfDamageTakenTime = 0; numberOfDamageTakenTime < fireTime; numberOfDamageTakenTime++)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            target.GetComponent<MonsterHealth>().TakeDamage(skill.damage);
            yield return new WaitForSeconds(delayTime);
        }
    }
}
