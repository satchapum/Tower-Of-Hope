using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttactSystem : MonoBehaviour
{
    [SerializeField] GameObject attackArea;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    void Update()
    {
        if (InputManager.Instance.mouseLeftDown)
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0f;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
