using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Player Setting")]
    [SerializeField] float moveSpeed;
    [SerializeField] float playerRotationSpeed;

    [Header("Setup")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 movementDirection;

    void Update()
    {
        movementDirection = new Vector2 (InputManager.Instance.HorizontalInput , InputManager.Instance.VerticalInput);

        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotationPlayer = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotationPlayer, playerRotationSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        PlayerMove(movementDirection);
    }
    void PlayerMove(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
