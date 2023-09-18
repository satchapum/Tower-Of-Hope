using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Player Setting")]
    [SerializeField] float moveSpeed;
    [SerializeField] float playerRotationSpeed;

    [Header("Setup")] 
    [SerializeField] Vector2 movementDirection;
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementDirection = new Vector2 (InputManager.Instance.HorizontalInput , InputManager.Instance.VerticalInput);
        
        //if (movementDirection != Vector2.zero)
        //{
        //    Quaternion toRotationPlayer = Quaternion.LookRotation(Vector3.forward, movementDirection);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotationPlayer, playerRotationSpeed * Time.deltaTime);
        //}
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


    void PlayerMove(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
