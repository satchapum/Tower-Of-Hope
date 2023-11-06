using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFrost : MonoBehaviour
{
    [SerializeField] ArrowMagicWand_Skill skill;
    [SerializeField] int daggerSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float delayTime;
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
            StartCoroutine(DoSlow(monsterTarget));
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
    IEnumerator DoSlow(GameObject target)
    {
        int monsterSpeedTemp = target.GetComponent<MonsterBehavior>().monsterSpeed;
        target.GetComponent<MonsterBehavior>().monsterSpeed = target.GetComponent<MonsterBehavior>().monsterSpeed / 2;
        target.GetComponent<SpriteRenderer>().color = Color.blue;
        yield return new WaitForSeconds(delayTime);
        target.GetComponent<MonsterBehavior>().monsterSpeed = monsterSpeedTemp;
        target.GetComponent<SpriteRenderer>().color = Color.white;
        Destroy(gameObject);
    }
}
