using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : Singleton<Player_Movement>
{
    [Header("Player Setting")]
    [SerializeField] public float moveSpeed;

    [Header("Setup")] 
    [SerializeField] public Vector2 movementDirection;
    [SerializeField] GameObject player;
    [SerializeField] GameObject colliderCheck;
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("Position Of Check Collider And Attack")]
    [SerializeField] GameObject posLeft;
    [SerializeField] GameObject posRight;
    [SerializeField] GameObject posTop;
    [SerializeField] GameObject posBottom;

    [Header("Dash")]
    [SerializeField] Transform moveBackPosition;
    [SerializeField] Vector2 currentPosVec;
    [SerializeField] float dashSpeed = 10;
    [SerializeField] float moveBackDashSpeed = 20;
    [SerializeField] float dashTime = 1f;
    [SerializeField] public TrailRenderer tr;
    [SerializeField] public bool isBackWardDash = false;

    [Header("MoveToMonster")]
    [SerializeField] public bool isMoveToMonster = false;
    [SerializeField] public GameObject monsterTarget;
    [SerializeField] SwordSpear_Skill swordSpear_Skill;

    Rigidbody2D rb;
    Animator anim;

    private void Start()
    {
        tr.emitting = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = player.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isMoveToMonster)
        {
            movementDirection = new Vector2(InputManager.Instance.HorizontalInput, InputManager.Instance.VerticalInput);

            if (isBackWardDash)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveBackPosition.position, moveBackDashSpeed * Time.deltaTime);
            }
        }
        
    }

    void FixedUpdate()
    {
        PlayerMove(movementDirection);
        anim.SetBool("Running", false);

        if (movementDirection.x < 0)
        {
            AudioManager.Instance.walk_Sound_SFX();
            FlipLeft();
        }
        else if (movementDirection.x > 0)
        {
            AudioManager.Instance.walk_Sound_SFX();
            FlipRight();
        }
        else if (movementDirection.y < 0)
        {
            AudioManager.Instance.walk_Sound_SFX();
            FlipDown();
        }
        else if (movementDirection.y > 0)
        {
            AudioManager.Instance.walk_Sound_SFX();
            FlipUp();
        }
        else if (movementDirection.x == 0 && movementDirection.y == 0)
        {
            AudioManager.Instance.stop_walk_Sound_SFX();
        }
    }

    public void JumpToMonster(GameObject monster)
    {
        monsterTarget = monster;
        float moveSpeedMultiply =  5;
        transform.position = Vector3.MoveTowards(transform.position, monster.transform.position, moveSpeed * moveSpeedMultiply * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == monsterTarget)
        {
            swordSpear_Skill.isSkilluse = false;
            player.GetComponent<Player_Movement>().isMoveToMonster = false;
            player.GetComponent<Player_health>().healPlayerHealt(swordSpear_Skill.amountOfHeal);
            monsterTarget.GetComponent<MonsterHealth>().TakeDamage(swordSpear_Skill.damage);
        }

    }

    void FlipRight()
    {
        spriteRenderer.flipX = true;
        ChangeRotation(90f);
        SetPosition(posRight);
        anim.SetBool("Running", true);
    }

    void FlipLeft()
    {
        spriteRenderer.flipX = false;
        ChangeRotation(-90f);
        SetPosition(posLeft);
        anim.SetBool("Running", true);
    }

    void FlipUp()
    {
        spriteRenderer.flipX = false;
        ChangeRotation(180f);
        SetPosition(posTop);
        anim.SetBool("Running", true);
    }

    void FlipDown()
    {
        spriteRenderer.flipX = false;
        ChangeRotation(0f);
        SetPosition(posBottom);
        anim.SetBool("Running", true);
    }

    void ChangeRotation(float degree)
    {
        colliderCheck.transform.rotation = Quaternion.Euler(0f, 0f, degree);
    }

    void SetPosition(GameObject targetPosition)
    {
        colliderCheck.transform.position = targetPosition.transform.position;
    }

    void PlayerMove(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public IEnumerator DoDash()
    {
        float speedTemp = moveSpeed;
        tr.emitting = true;
        moveSpeed = dashSpeed;
        yield return new WaitForSeconds(dashTime);
        moveSpeed = speedTemp;
        tr.emitting = false;
    }

    
}
