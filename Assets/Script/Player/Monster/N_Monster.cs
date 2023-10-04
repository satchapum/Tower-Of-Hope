using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Monster : Monster
{
    [SerializeField] GameObject monsterGameobject;
    [SerializeField] int minAmount = 2;
    [SerializeField] int maxAmount = 5;
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
}
