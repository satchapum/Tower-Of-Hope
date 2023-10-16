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

    public event Action<int> onTakeDamage;

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
        maxHealth = GameManager.Instance.currentFloor * maxHealth;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
            return;
        
        else if (currentHealth > 0)
        {
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
}
