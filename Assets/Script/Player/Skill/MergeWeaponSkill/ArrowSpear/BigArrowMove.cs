using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigArrowMove : MonoBehaviour
{
    [SerializeField] float effectSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float currentDisplaytime;
    [SerializeField] float targetScale;
    [SerializeField] ArrowSpear_Skill skill;

    void Start()
    {
        rb.velocity = transform.right * effectSpeed;
        StartCoroutine(EffectDestroy());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var monster in GameObject.FindObjectsOfType<Monster>())
        {

            if (collision.gameObject == monster.gameObject)
            {
                monster.gameObject.GetComponent<MonsterHealth>().TakeDamage(skill.damage);
            }
        }
    }

    private void Update()
    {
        currentDisplaytime += Time.deltaTime;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, Mathf.Lerp(gameObject.transform.localScale.y, targetScale, currentDisplaytime / 3f), gameObject.transform.localScale.z);
    }

    IEnumerator EffectDestroy()
    {
        yield return new WaitForSeconds(skill.timeToDestroy);
        Destroy(gameObject);
    }
}
