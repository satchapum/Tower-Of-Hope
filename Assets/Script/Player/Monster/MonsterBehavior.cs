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
            else if( direction.x < 0)
            {
                FlipLeft();
                return;
            }
            FlipUp();
            return;
        }
    }

    void FlipRight()
    {

        spriteRenderer.flipX = false;
        //ChangeRotation(90f);
        //anim.SetBool("Running", true);
    }

    void FlipLeft()
    {

        spriteRenderer.flipX = true;
        //ChangeRotation(-90f);
        //anim.SetBool("Running", true);
    }

    void FlipUp()
    {

        spriteRenderer.flipX = false;
        //ChangeRotation(180f);
    }

    void FlipDown()
    {
        spriteRenderer.flipX = false;
        //ChangeRotation(0f);
        //anim.SetBool("Running", true);
    }

    /*
    void ChangeRotation(float degree)
    {
        colliderCheck.transform.rotation = Quaternion.Euler(0f, 0f, degree);
    }*/
}
