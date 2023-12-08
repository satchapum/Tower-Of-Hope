using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform targetBoss;
    [SerializeField] float rotateSpeed;
    [SerializeField] int damage;
    [SerializeField] float timeToDestroy;
    [SerializeField] Boss_Script boss_Script;


    private void Start()
    {
        StartCoroutine(DestroyDelay());
    }

    void Update()
    {
        if (boss_Script == null)
        {
            Destroy(this.gameObject);
        }
        transform.RotateAround(targetBoss.transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            Player_health.Instance.TakeDamage(damage);
        }
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(timeToDestroy);
        AudioManager.Instance.Stop_bossSkill_2_sound_SFX();
        Destroy(this.gameObject);
    }
}
