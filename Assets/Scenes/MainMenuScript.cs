using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void WhenButtonStartClick()
    {
        int numberOfFirstScene = 1;
        SceneManager.LoadScene(numberOfFirstScene);
    }
}
