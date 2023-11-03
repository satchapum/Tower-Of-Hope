using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationScript : MonoBehaviour
{
    [SerializeField] GameObject informationUI;
    [SerializeField] bool IsOpenInformationUI;
    public void WhenButtonInformationClick()
    {
        int numberToStopGame = 0;
        int numberToStartGame = 1;
        if (IsOpenInformationUI == true)
        {
            Time.timeScale = numberToStartGame;
            informationUI.SetActive(false);
            IsOpenInformationUI = false;
        }
        else if (IsOpenInformationUI == false)
        {
            Time.timeScale = numberToStopGame;
            informationUI.SetActive(true);
            IsOpenInformationUI = true;
        }
    } 
}
