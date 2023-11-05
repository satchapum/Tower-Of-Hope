using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearOutput : MonoBehaviour
{
    [SerializeField] float spearSpeed;
    [SerializeField] Transform spearTarget;
    [SerializeField] int numberOfRound = 5;
    [SerializeField] float spearDelay = 0.2f;
    [SerializeField] Transform currentTarget;
    [SerializeField] Transform tempTarget;
    [SerializeField] Spear spear;

    void Start()
    {
        currentTarget = spearTarget;
        StartCoroutine(ChangeTargetPosition());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, spearSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var monster in GameObject.FindObjectsOfType<Monster>())
        {
            if (collision.gameObject == monster.gameObject)
                collision.gameObject.GetComponent<MonsterHealth>().TakeDamage(spear.damage + GameManager.Instance.playerBaseAttackDamage);
        }
    }

    IEnumerator ChangeTargetPosition()
    {
        for (int numberOfCurrentRound = 0; numberOfCurrentRound < numberOfRound; numberOfCurrentRound++)
        {
            if (currentTarget == spearTarget)
            {
                Debug.Log("change to temp");
                currentTarget = tempTarget;
                yield return new WaitForSeconds(spearDelay);
            }
            else if (currentTarget == tempTarget)
            {
                Debug.Log("change to target");
                currentTarget = spearTarget;
                yield return new WaitForSeconds(spearDelay);
            }
            
        }
        Destroy(gameObject);
    }
}
