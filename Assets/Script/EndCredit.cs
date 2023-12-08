using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndCredit : MonoBehaviour
{
    [SerializeField] TMP_Text endCreditText;
    private void Start()
    {
        var maxbounds = endCreditText.bounds;
        Debug.Log(maxbounds);
    }
}
