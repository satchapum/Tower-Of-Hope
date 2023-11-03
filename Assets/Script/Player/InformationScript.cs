using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationScript : MonoBehaviour
{
    [SerializeField] GameObject informationUI;
    [SerializeField] bool IsOpenInformationUI;
    public void WhenButtonInformationClick()
    {
        if(IsOpenInformationUI == true)
        {
            informationUI.SetActive(false);
            IsOpenInformationUI = false;
        }
        else if (IsOpenInformationUI == false)
        {
            informationUI.SetActive(true);
            IsOpenInformationUI = true;
        }
    } 
}
