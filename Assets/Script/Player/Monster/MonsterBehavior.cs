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
    [SerializeField] public int monsterSpeed;
    [SerializeField] int numberOfExperience = 10;

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
        Player_level.Instance.GetLevelExperience(numberOfExperience);
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
    }

    void FlipLeft()
    {
        spriteRenderer.flipX = true;
    }

    void FlipUp()
    {

        spriteRenderer.flipX = false;
    }

    void FlipDown()
    {
        spriteRenderer.flipX = false;
    }
}
