using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWandFire : MonoBehaviour
{
    [SerializeField] MagicWand_Skill magicWand_Skill;
    [SerializeField] float currentDisplaytime;
    [SerializeField] float targetScale;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var monster in GameObject.FindObjectsOfType<Monster>())
        {
            if (collision.gameObject == monster.gameObject)
                collision.gameObject.GetComponent<MonsterHealth>().TakeDamage(magicWand_Skill.damage + GameManager.Instance.playerBaseAttackDamage);
        }
    }

    private void Update()
    {
        currentDisplaytime += Time.deltaTime;
        gameObject.transform.localScale = new Vector3(Mathf.Lerp(gameObject.transform.localScale.x, targetScale, currentDisplaytime / 3f), Mathf.Lerp(gameObject.transform.localScale.y, targetScale, currentDisplaytime / 3f), gameObject.transform.localScale.z);
    }
}
