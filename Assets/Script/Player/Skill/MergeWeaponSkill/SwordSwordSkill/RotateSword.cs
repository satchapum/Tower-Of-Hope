using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSword : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;
    [SerializeField] float rotateSpeed;
    [SerializeField] Sword sword;
    void Update()
    {
        transform.RotateAround(targetPlayer.transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var monster in GameObject.FindObjectsOfType<Monster>())
        {
            if (collision.gameObject == monster.gameObject)
                collision.gameObject.GetComponent<MonsterHealth>().TakeDamage(sword.damage);

        }
    }
}
