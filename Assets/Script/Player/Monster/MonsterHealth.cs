using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int CurrentHealth => currentHealth;
    [SerializeField] int currentHealth;

    [SerializeField] GameObject player;
    [SerializeField] GameObject thisMonsterObject;
    [SerializeField] MonsterBehavior monsterBehavior;
    [SerializeField] TMP_Text damageText;
    [SerializeField] int amountOfHealtWhenChangeFloor = 2;

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
        if (GameManager.Instance.currentMonsterCount == 0)
        {
            ItemDrop.Instance.dropItem(gameObject.transform);
        }
        Destroy(thisMonsterObject);
    }

    void Start()
    {
        maxHealth = (GameManager.Instance.currentFloor * amountOfHealtWhenChangeFloor) + maxHealth;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
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
}
