using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Monster;
    [SerializeField] bool isTargetPlayer;
    [SerializeField] PlayerSetting playerSetting;
    [SerializeField] int monsterSpeed;

    Rigidbody2D thisMonsterRb;
    void Start()
    {
        thisMonsterRb = Monster.GetComponent<Rigidbody2D>();
        WhenMonsterSetting();
    }

    void WhenMonsterSetting()
    {
        if (playerSetting.NumberOfCurrentMonsterTargetOnPlayer < playerSetting.maximunOfMonsterTargetOnplayer && !isTargetPlayer)
        {
            playerSetting.NumberOfCurrentMonsterTargetOnPlayer++;
            isTargetPlayer = true;
        }
    }

    public void WhenMonsterDestroy()
    {
        playerSetting.NumberOfCurrentMonsterTargetOnPlayer--;
        isTargetPlayer = false;
    }

    void Update()
    {
        WhenMonsterSetting();

        if (isTargetPlayer)
            MonsterFollowObject(Player);

        else if (!isTargetPlayer)
            return;
    }

    void MonsterFollowObject(GameObject inputObject)
    {
        Vector3 position = Vector3.MoveTowards(transform.position, inputObject.transform.position, monsterSpeed * Time.deltaTime);
        thisMonsterRb.MovePosition(position);
        
        Vector3 lookAt = transform.InverseTransformPoint(inputObject.transform.position);
        float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0, 0, angle);
    }
}
