using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : WeaponManager
{
    [SerializeField] float effectSpeed;
    [SerializeField] public int damage = 2;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float effectShowTime;
    [SerializeField] float currentDisplaytime;
    [SerializeField] float targetScale;

    [SerializeField] float AttackCooldown = 1;
    public override float attackCooldown { get { return this.AttackCooldown; } set { this.AttackCooldown = value; } }

    void Start()
    {
        rb.velocity = transform.right * effectSpeed;
        AudioManager.Instance.magicWand_Sound_SFX();
        StartCoroutine("effectDestroy");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var monster in GameObject.FindObjectsOfType<Monster>())
        {
            if (collision.gameObject == monster.gameObject)
                collision.gameObject.GetComponent<MonsterHealth>().TakeDamage(damage + GameManager.Instance.playerBaseAttackDamage);
        }
    }

    private void Update()
    {
        currentDisplaytime += Time.deltaTime;
        gameObject.transform.localScale = new Vector3(Mathf.Lerp(gameObject.transform.localScale.x, targetScale, currentDisplaytime / 3f), Mathf.Lerp(gameObject.transform.localScale.y, targetScale, currentDisplaytime / 3f), Mathf.Lerp(gameObject.transform.localScale.z, targetScale, currentDisplaytime / 3f));
    }

    IEnumerator effectDestroy()
    {
        yield return new WaitForSeconds(effectShowTime);
        Destroy(gameObject);
    }
}
