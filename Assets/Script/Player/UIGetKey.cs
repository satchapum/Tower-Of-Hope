using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGetKey : Singleton<UIGetKey>
{
    [SerializeField] TMP_Text getKeyText;
    public void GetKeyText()
    {
        StartCoroutine(textGetKeyShow());
    }
    IEnumerator textGetKeyShow()
    {
        getKeyText.text = "Get Key Alr!!!";
        yield return new WaitForSeconds(2);
        getKeyText.text = "";
    }
}
