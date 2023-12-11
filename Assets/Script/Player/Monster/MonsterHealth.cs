using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int CurrentHealth => currentHealth;
    [SerializeField] public int currentHealth;

    [SerializeField] GameObject player;
    [SerializeField] GameObject thisMonsterObject;
    [SerializeField] MonsterBehavior monsterBehavior;
    [SerializeField] TMP_Text damageText;
    [SerializeField] int amountOfHealthWhenChangeFloor = 2;
    [SerializeField] string monsterName;

    private void Update()
    {
        if (currentHealth <= 0)
        {
            monsterDie();
        }
    }

    void monsterDie()
    {
        monsterBehavior.WhenMonsterDestroy();
        GameManager.Instance.currentMonsterCount = GameManager.Instance.currentMonsterCount - 1;
        if (monsterName == "Boss")
        {
            GameManager.Instance.IsFinalBossDie = true;
            AudioManager.Instance.Stop_bossSkill_2_sound_SFX();
            Destroy(thisMonsterObject);
        }
        if (GameManager.Instance.currentMonsterCount == 0)
        {
            ItemDrop.Instance.dropItem(gameObject.transform);
        }
        Destroy(thisMonsterObject);
    }

    void Start()
    {
        maxHealth = (GameManager.Instance.currentFloor * amountOfHealthWhenChangeFloor) + maxHealth;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        AudioManager.Instance.Monster_TakeDamage_Sound_SFX(monsterName);
        if (currentHealth <= 0)
            return;
        
        else if (currentHealth > 0)
        {
            StartCoroutine(DamageTakeFeedback());
            damageText.text = "-" + (damage);
            StartCoroutine(TextAnimation());
            currentHealth -= damage;
            
        }
        
    }

    IEnumerator TextAnimation()
    {
        damageText.enabled = true;
        yield return new WaitForSeconds(1f);
        damageText.enabled = false;
    }

    IEnumerator DamageTakeFeedback()
    {
        float takeDamageFeedbackTime = 0.5f;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(takeDamageFeedbackTime);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public IEnumerator DoDamageBleeding(int numberOfTimeDoDamage, int damage, float delayTime)
    {
        for (int numberOfDamageTakenTime = 0; numberOfDamageTakenTime < numberOfTimeDoDamage; numberOfDamageTakenTime++)
        {
            yield return new WaitForSeconds(delayTime);
            int  monsterTakeDamage = (currentHealth * damage) / 100;
            TakeDamage(monsterTakeDamage); 
        }
    }
}
