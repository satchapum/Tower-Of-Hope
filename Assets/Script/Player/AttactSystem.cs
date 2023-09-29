using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttactSystem : MonoBehaviour
{
    [SerializeField] GameObject attackPosition;
    [SerializeField] List<GameObject> attackPrefab;
    [SerializeField] float attackForce;
    [SerializeField] string currentWeapon;

    private bool attacking = false;

    private float timeToAttack = 1f;
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
            }
        }
    }

    void Attack()
    {
        attacking = true;
        createAttack();
    }
  
    void createAttack()
    {
        foreach (var weapon in attackPrefab)
        {
            if (weapon.name == "Sword") 
            {
                Instantiate(weapon, attackPosition.transform.position, Quaternion.identity);
            }
        }
    }
}
