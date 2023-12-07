using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject mainmenuCanvas;
    [SerializeField] GameObject optionCanvas;
    public void WhenButtonStartClick()
    {
        int numberOfFirstScene = 1;
        SceneManager.LoadScene(numberOfFirstScene);
    }
    public void WhenButtonQuitClick()
    {
        Application.Quit();
    }
    public void WhenOptionButtonClick()
    {
        mainmenuCanvas.SetActive(false);
        optionCanvas.SetActive(true);
    }
    
    public void WhenBackToMainmenuButtonClick()
    {
        mainmenuCanvas.SetActive(true);
        optionCanvas.SetActive(false);
    }
}
