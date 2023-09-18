using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Monster;
    [SerializeField] bool isTargetPlayer;
    [SerializeField] PlayerSetting playerSetting;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] int monsterSpeed;

    Rigidbody2D thisMonsterRb;
    void Start()
    {
        thisMonsterRb = Monster.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        Vector2 direction = (inputObject.transform.position - transform.position).normalized;

        if (direction.y < 0)
        {
            if (direction.x < 0)
            {
                FlipLeft();
                return;
            }
            FlipDown();
            return;
        }
        else if (direction.y > 0)
        {
            if (direction.x > 0)
            {
                FlipRight();
                return;
            }
            FlipUp();
            return;
        }
    }

    void FlipRight()
    {
        spriteRenderer.flipX = false;
        transform.rotation = Quaternion.Euler(0f, 0f, -90f);
    }

    void FlipLeft()
    {
        spriteRenderer.flipX = true;
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }

    void FlipUp()
    {
        spriteRenderer.flipX = false;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void FlipDown()
    {
        spriteRenderer.flipX = false;
        transform.rotation = Quaternion.Euler(0f, 0f, 180f);
    }
}
