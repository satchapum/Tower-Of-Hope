using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bunker;
    [SerializeField] float timeToDestroy;
    [SerializeField] int damage;
    private Vector3 movementVector = Vector3.zero;
    [SerializeField] float moveSpeed =1f;

    void Start()
    {
        StartCoroutine(DestroyDelay());
    }

    void Update()
    {
        transform.position += movementVector * Time.deltaTime * moveSpeed;
    }

    public void SetMovementVector(Vector3 newMovementVector)
    {
        movementVector = newMovementVector.normalized;
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == bunker)
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject == player)
        {
            Player_health.Instance.TakeDamage(damage);
            Destroy(this.gameObject);
        }
            
    }
}
