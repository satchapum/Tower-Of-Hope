using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerDagger_Skill_Create : MonoBehaviour
{
    [SerializeField] float effectSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float currentDisplaytime;
    [SerializeField] float targetScale;
    [SerializeField] DaggerDagger_Skill skill;
    void Start()
    {
        rb.velocity = transform.right * effectSpeed;
        StartCoroutine("effectDestroy");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var monster in GameObject.FindObjectsOfType<Monster>())
        {
            if (collision.gameObject == monster.gameObject)
                collision.gameObject.GetComponent<MonsterHealth>().TakeDamage(skill.damage);
        }
    }

    private void Update()
    {
        currentDisplaytime += Time.deltaTime;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, Mathf.Lerp(gameObject.transform.localScale.y, targetScale, currentDisplaytime / 3f), gameObject.transform.localScale.z);
    }

    IEnumerator effectDestroy()
    {
        yield return new WaitForSeconds(skill.timeToDestroy);
        Destroy(gameObject);
    }
}
