using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] bool isTargetPlayer;
    [SerializeField] PlayerSetting playerSetting;
    [SerializeField] Rigidbody2D thisMonsterRb;
    [SerializeField] int monsterSpeed;
    void Start()
    {
        WhenMonsterSpawn();
    }

    void WhenMonsterSpawn()
    {
        playerSetting.numberOfCurrentMonsterTarget++;
        if (playerSetting.numberOfCurrentMonsterTarget <= 3)
        {
            isTargetPlayer = true;
        }
    }

    void WhenMonsterDestroy()
    {
        playerSetting.numberOfCurrentMonsterTarget--;
    }

    void Update()
    {
        if (isTargetPlayer)
        {
            MonsterFollowPlayer();
        }
        else if (!isTargetPlayer)
        {

        }
    }

    void MonsterFollowMonster()
    {
        Vector3 positionOfPlayer = Vector3.MoveTowards(transform.position, Player.transform.position, monsterSpeed * Time.deltaTime);
        thisMonsterRb.MovePosition(positionOfPlayer);

        Vector3 lookAt = transform.InverseTransformPoint(Player.transform.position);
        float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0, 0, angle);
    }

    void MonsterFollowPlayer()
    {
        Vector3 positionOfPlayer = Vector3.MoveTowards(transform.position, Player.transform.position, monsterSpeed * Time.deltaTime);
        thisMonsterRb.MovePosition(positionOfPlayer);
        
        Vector3 lookAt = transform.InverseTransformPoint(Player.transform.position);
        float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0, 0, angle);
    }
}
