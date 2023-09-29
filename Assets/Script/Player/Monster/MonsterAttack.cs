using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] public float attackDelayTime = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var player in GameObject.FindObjectsOfType<Player_health>())
        {
            if (collision.gameObject == player.gameObject)
            {
                player.gameObject.GetComponent<Player_health>().TakeDamage(damage);
            }
        }
    }
}
