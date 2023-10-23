using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] public float attackDelayTime = 1;
    [SerializeField] int damageUpgradePerFloor = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var player in GameObject.FindObjectsOfType<Player_health>())
        {
            if (collision.gameObject == player.gameObject)
            {
                //Addanimation<==
                gameObject.GetComponent<Monster>().WhenAttack();
                StartCoroutine(monsterAttackDelay());
                player.gameObject.GetComponent<Player_health>().TakeDamage(damage + (GameManager.Instance.currentFloor * damageUpgradePerFloor));
            }
        }
    }

    IEnumerator monsterAttackDelay()
    {
        yield return new WaitForSeconds(attackDelayTime);
    }
}
