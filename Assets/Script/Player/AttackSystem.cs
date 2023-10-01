using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] GameObject attackPosition;
    [SerializeField] public List<GameObject> attackPrefab;

    [SerializeField] public string currentWeapon_Lefthand;
    [SerializeField] public string currentWeapon_Righthand;

    [Header("UITimeDelay")]
    [SerializeField] public Image attack_LeftDelayUI;
    [SerializeField] public Image attack_RightDelayUI;

    public bool attacking_Left = false;
    public bool attacking_Right = false;

    [SerializeField] public int numberSlotSelect = 0;

    //cangetfromweapon
    public float TimeToAttackLeft => timeToAttackLeft;
    [SerializeField] float timeToAttackLeft = 1f;
    [SerializeField] float timeToAttackRight = 1f;
    public float timer_left = 0f;
    public float timer_right = 0f;

    void Update()
    {
        if (attacking_Left == false && InputManager.Instance.mouseLeftDown)
        {
            Attack("left");

        }
        else if (attacking_Right == false && InputManager.Instance.mouseRightDown)
        {
            Attack("right");
        }
    }

    public void OnbuttonSelectSlotClick(int numberSlot)
    {
        numberSlotSelect = numberSlot;
    }

    IEnumerator attackLeftDelay()
    {
        while (timer_left < timeToAttackLeft)
        {
            attack_LeftDelayUI.fillAmount = timer_left;
            timer_left += Time.deltaTime;
            yield return null;
        }
        timer_left = 0f;
        attacking_Left = false;
    }
    IEnumerator attackRightDelay()
    {
        while (timer_right < timeToAttackRight)
        {
            attack_RightDelayUI.fillAmount = timer_right;
            timer_right += Time.deltaTime;
            yield return null;
        }
        timer_right = 0f;
        attacking_Right = false;
    }
    void Attack(string hand)
    {
        if (hand == "left")
        {
            attacking_Left = true;
            createAttack("left");
            StartCoroutine(attackLeftDelay());
        }
        else if (hand == "right")
        {
            attacking_Right = true;
            createAttack("right");
            StartCoroutine(attackRightDelay());
        }

    }
  
    void createAttack(string hand)
    {
        Vector3 effectRotate = new Vector3(attackPosition.transform.rotation.x, attackPosition.transform.rotation.x, attackPosition.transform.rotation.z + 90);
        if (hand == "left")
        {
            foreach (var weapon in attackPrefab)
            {
                if (weapon.name == currentWeapon_Lefthand)
                {
                    GameObject newEffect = Instantiate(weapon, attackPosition.transform.position, attackPosition.transform.rotation);
                    newEffect.SetActive(true);
                    newEffect.transform.Rotate(effectRotate);
                }
            }
        }
        else if (hand == "right")
        {
            foreach (var weapon in attackPrefab)
            {
                if (weapon.name == currentWeapon_Righthand)
                {
                    GameObject newEffect = Instantiate(weapon, attackPosition.transform.position, attackPosition.transform.rotation);
                    newEffect.SetActive(true);
                    newEffect.transform.Rotate(effectRotate);
                }
            }
        }
    }
}
