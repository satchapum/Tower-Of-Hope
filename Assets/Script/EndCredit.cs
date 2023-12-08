using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndCredit : MonoBehaviour
{
    [SerializeField] TMP_Text endCreditText;
    private void Start()
    {
        var maxbounds = endCreditText.bounds;
        Debug.Log(maxbounds);
    }

    void ReturnToMainMenu()
    {
        GameManager.Instance.ResetData();
        SceneManager.LoadScene(0);
    }
}
