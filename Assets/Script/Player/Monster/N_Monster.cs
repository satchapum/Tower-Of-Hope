using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Monster : Monster
{
    [SerializeField] GameObject monsterGameobject;
    [SerializeField] int minAmount = 2;
    [SerializeField] int maxAmount = 5;

    [Header("WhenAttackSetting")]
    [SerializeField] int speedWhenAttack;
    [SerializeField] float delayTime;

    public override void WhenAttack()
    {
        Debug.Log(gameObject.name + "stop : " + delayTime);
        int currentMonsterSpeed = gameObject.GetComponent<MonsterBehavior>().monsterSpeed;
        StartCoroutine(DelayTime(currentMonsterSpeed));
    }
    public override void SpawnMonster(Vector2 chestPosition)
    {
        var randomNumberOfAmount = Random.Range(minAmount, maxAmount);
        for (int numberOfMinAmountMonster = 0; numberOfMinAmountMonster <= randomNumberOfAmount; numberOfMinAmountMonster++)
        {
            var monster = Instantiate(monsterGameobject, chestPosition, Quaternion.identity);
            GameManager.Instance.currentMonsterCount++;
            monster.SetActive(true);
        } 
    }
    IEnumerator DelayTime(int currentMonsterSpeed)
    {
        gameObject.GetComponent<MonsterBehavior>().monsterSpeed = speedWhenAttack;
        yield return new WaitForSeconds(delayTime);
        gameObject.GetComponent<MonsterBehavior>().monsterSpeed = currentMonsterSpeed;
    }
}
