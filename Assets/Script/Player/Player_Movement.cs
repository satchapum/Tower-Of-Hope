using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : Singleton<Player_Movement>
{
    [Header("Player Setting")]
    [SerializeField] float moveSpeed;
    [SerializeField] float playerRotationSpeed;

    [Header("Setup")] 
    [SerializeField] Vector2 movementDirection;
    [SerializeField] GameObject player;
    [SerializeField] GameObject colliderCheck;
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("Position Of Check Collider And Attack")]
    [SerializeField] GameObject posLeft;
    [SerializeField] GameObject posRight;
    [SerializeField] GameObject posTop;
    [SerializeField] GameObject posBottom;

    Rigidbody2D rb;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementDirection = new Vector2 (InputManager.Instance.HorizontalInput , InputManager.Instance.VerticalInput);
    }

    void FixedUpdate()
    {
        PlayerMove(movementDirection);

        if (movementDirection.x < 0)
        {
            FlipLeft();
        }
        else if (movementDirection.x > 0)
        {
            FlipRight();
        }
        else if (movementDirection.y < 0)
        {
            FlipDown();
        }
        else if (movementDirection.y > 0)
        {
            FlipUp();
        }
    }
    void FlipRight()
    {
        spriteRenderer.flipX = true;
        ChangeRotation(90f);
        SetPosition(posRight);
    }

    void FlipLeft()
    {
        spriteRenderer.flipX = false;
        ChangeRotation(-90f);
        SetPosition(posLeft);
    }

    void FlipUp()
    {
        spriteRenderer.flipX = false;
        ChangeRotation(180f);
        SetPosition(posTop);
    }

    void FlipDown()
    {
        spriteRenderer.flipX = false;
        ChangeRotation(0f);
        SetPosition(posBottom);
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
}
