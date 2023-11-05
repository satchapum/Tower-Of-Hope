using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Monster : Monster
{
    [SerializeField] GameObject monsterGameobject;
    [SerializeField] MonsterAttack monsterAttack;
    [SerializeField] int minAmount = 2;
    [SerializeField] int maxAmount = 5;

    [Header("WhenAttackSetting")]
    [SerializeField] int speedWhenAttack;
    [SerializeField] float delayTime;
    [SerializeField] int currentMonsterSpeed;

    private void Start()
    {
        currentMonsterSpeed = gameObject.GetComponent<MonsterBehavior>().monsterSpeed;
    }

    public override void WhenAttack()
    {
        Debug.Log(gameObject.name + "stop : " + delayTime);
        StartCoroutine(DelayTime());
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
    IEnumerator DelayTime()
    {
        int monsterAttackDamage = monsterAttack.damage;
        int damageWhenAttackFinish = 0;
        monsterGameobject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        monsterAttack.damage = damageWhenAttackFinish;
        gameObject.GetComponent<MonsterBehavior>().monsterSpeed = speedWhenAttack;
        yield return new WaitForSeconds(delayTime);
        gameObject.GetComponent<MonsterBehavior>().monsterSpeed = currentMonsterSpeed;
        monsterGameobject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        monsterGameobject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        monsterAttack.damage = monsterAttackDamage;
    }
}
