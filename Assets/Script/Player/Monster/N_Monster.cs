using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Monster : Monster
{
    [SerializeField] float thisMonsterIndex = 0;
    [SerializeField] GameObject monsterGameobject;
    [SerializeField] int minAmount = 2;
    [SerializeField] int maxAmount = 5;
    public override void SpawnMonster(Vector2 chestPosition)
    {
        var randomNumberOfAmount = Random.Range(minAmount, maxAmount);
        for (int numberOfMinAmountMonster = minAmount; numberOfMinAmountMonster < maxAmount; numberOfMinAmountMonster++)
        {
            var monster = Instantiate(monsterGameobject, chestPosition, Quaternion.identity);
            monster.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
            monster.SetActive(true);
        }
        
    }
}
