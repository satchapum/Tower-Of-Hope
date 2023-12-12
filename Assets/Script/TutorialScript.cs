using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] TMP_Text tutorialText;
    [SerializeField] GameObject textBox;

    [Header("Status")]
    [SerializeField] int numberOfAdvice = 0;
    [SerializeField] bool IsAdvice = false;
    void Start()
    {
        StartCoroutine(GameIntro());
        GameManager.Instance.IsTutorial = true;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.currentWeapon_Lefthand == "Wrench" && numberOfAdvice == 1)
        {
            numberOfAdvice++;
            IsAdvice = false;
        }
        else if (GameManager.Instance.currentMonsterCount > 0 && numberOfAdvice == 2)
        {
            numberOfAdvice++;
            IsAdvice = false;
        }
        else if (GameManager.Instance.currentMonsterCount <= 0 && numberOfAdvice == 3)
        {
            numberOfAdvice++;
            IsAdvice = false;
        }

        if (numberOfAdvice == 1 && IsAdvice == false)
        {
            IsAdvice = true;
            textBox.SetActive(true);
            StartCoroutine(PickSystemAdvice());
        }
        else if (numberOfAdvice == 2 && IsAdvice == false)
        {
            IsAdvice = true;
            textBox.SetActive(true);
            StartCoroutine(WeaponSystemAdvice());
        }
        else if (numberOfAdvice == 3 && IsAdvice == false)
        {
            IsAdvice = true;
            textBox.SetActive(true);
            StartCoroutine(FightingAdvice());
        }
        else if (numberOfAdvice == 4 && IsAdvice == false)
        {
            if (GameManager.Instance.currentMonsterCount <= 0)
            {
                IsAdvice = true;
                textBox.SetActive(true);
                StartCoroutine(MonsterDropSystemAdvice());
            }
        }
        else if (numberOfAdvice == 5 && IsAdvice == false)
        {
            if (GameManager.Instance.currentMonsterCount <= 0)
            {
                IsAdvice = true;
                textBox.SetActive(true);
                StartCoroutine(ChangeFloorAdvice());
            }
        }
    }
    IEnumerator GameIntro()
    {

        tutorialText.text = "Welcome to the Tower of Hope.";
        yield return new WaitForSeconds(4);
        tutorialText.text = "There are many things to do at this tower.";
        yield return new WaitForSeconds(4);
        tutorialText.text = "But first you need to have a weapon.";
        yield return new WaitForSeconds(4);
        numberOfAdvice++;
        IsAdvice = false;
        textBox.SetActive(false);
    }
    IEnumerator PickSystemAdvice()
    {
        tutorialText.text = "You can go to the Wrench and pick it by pressing 'F' key.";
        yield return new WaitForSeconds(4);
        tutorialText.text = "";
        textBox.SetActive(false);
    }
    IEnumerator WeaponSystemAdvice()
    {
        tutorialText.text = "Now you have left hand weapon.";
        yield return new WaitForSeconds(3);
        tutorialText.text = "So you can find another one by openning the chest.";
        yield return new WaitForSeconds(3);
        tutorialText.text = "Now back to the main point you can normal attack by Left mouse click or Right mouse click It depends on the weapon you use.";
        yield return new WaitForSeconds(6);
        tutorialText.text = "As you know this is the Tower of Hope. So what is hope? ";
        yield return new WaitForSeconds(3);
        tutorialText.text = "Yes, it is opening the chest.";
        yield return new WaitForSeconds(2);
        tutorialText.text = "You can go to the chest and open it by pressing 'F' button.";
        yield return new WaitForSeconds(4);
        tutorialText.text = "";
        textBox.SetActive(false);

    }
    IEnumerator FightingAdvice()
    {
        tutorialText.text = "You really are unlucky.";
        yield return new WaitForSeconds(3);
        tutorialText.text = "But don't be sad, you can use this opportunity to practice.";
        yield return new WaitForSeconds(4);
        tutorialText.text = "";
        textBox.SetActive(false);
    } 

    IEnumerator MonsterDropSystemAdvice()
    {
        tutorialText.text = "You did great.";
        yield return new WaitForSeconds(2);
        tutorialText.text = "After defeating monsters, you will receive both experience points and potion.";
        yield return new WaitForSeconds(4);
        tutorialText.text = "So you can use it by walking closer and pressing the 'F' button.";
        yield return new WaitForSeconds(5);
        tutorialText.text = "Oh I almost forgot one more important system.";
        yield return new WaitForSeconds(3);
        tutorialText.text = "All weapon is having the uniqe skill so you can use by pressing the 'Q' and 'E' button.";
        yield return new WaitForSeconds(5);
        tutorialText.text = "But if you have two weapon you will have one more skill that combine from two weapon. So you can use by pressing the 'X' button.";
        yield return new WaitForSeconds(6);
        tutorialText.text = "";
        numberOfAdvice++;
        IsAdvice = false;
        textBox.SetActive(false);
    }
    IEnumerator ChangeFloorAdvice()
    {
        tutorialText.text = "This will be the last one you need to know.";
        yield return new WaitForSeconds(3);
        tutorialText.text = "You can go to the next floor by get the key.";
        yield return new WaitForSeconds(3);
        tutorialText.text = "So this is how can you getting the key.";
        yield return new WaitForSeconds(4);
        tutorialText.text = "First one is using you luck by open the chest and get the key.";
        yield return new WaitForSeconds(5);
        tutorialText.text = "Second one is opening every chest and you will get the key in the last chest";
        yield return new WaitForSeconds(5);
        tutorialText.text = "When you have a key you can go to the portal and pressing the 'F' button";
        yield return new WaitForSeconds(5);
        tutorialText.text = "So this is all you need to know";
        yield return new WaitForSeconds(3);
        tutorialText.text = "Good Luck!!!!";
        yield return new WaitForSeconds(3);
        tutorialText.text = "";
        textBox.SetActive(false);
        GameManager.Instance.IsTutorial = false;
    }
}
