using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGetKey : Singleton<UIGetKey>
{
    [SerializeField] GameObject getKeyText;
    public void GetKeyText()
    {
        StartCoroutine(textGetKeyShow());
    }
    IEnumerator textGetKeyShow()
    {
        getKeyText.SetActive(true);
        yield return new WaitForSeconds(2);
        getKeyText.SetActive(false);
    }
}
