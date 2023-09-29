using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttactSystem : MonoBehaviour
{
    [SerializeField] GameObject attackPosition;
    [SerializeField] List<GameObject> attackPrefab;
    [SerializeField] string currentWeapon;

    private bool attacking = false;

    [SerializeField] float timeToAttack = 1f;
    private float timer = 0f;

    void Update()
    {
        if (attacking == false && InputManager.Instance.mouseLeftDown)
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
        Vector3 effectRotate = new Vector3(attackPosition.transform.rotation.x, attackPosition.transform.rotation.x, attackPosition.transform.rotation.z + 90);

        
        foreach (var weapon in attackPrefab)
        {
            if (weapon.name == "Sword") 
            {
                GameObject newEffect = Instantiate(weapon, attackPosition.transform.position, attackPosition.transform.rotation);
                newEffect.transform.Rotate(effectRotate);
            }
        }
    }
}
