using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject optionUI;
    [SerializeField] bool IsPause;

    void Update()
    {
        int numberOftimeToStartGame = 1;
        int numberOftimeToStopGame = 0;
        if (InputManager.Instance.KeyESC_Down && IsPause == true)
        {
            pauseUI.SetActive(false);
            optionUI.SetActive(false);
            IsPause = false;
            Time.timeScale = numberOftimeToStartGame;
        }
        else if (InputManager.Instance.KeyESC_Down && IsPause == false)
        {
            
            pauseUI.SetActive(true);
            IsPause = true;
            Time.timeScale = numberOftimeToStopGame;
        }
    }

    public void WhenButtonResumeClickOnPause()
    {
        int numberOftimeToStartGame = 1;
        Time.timeScale = numberOftimeToStartGame;
        IsPause = false;
        pauseUI.SetActive(false);
    }

    public void WhenOptionButtonClick()
    {
        pauseUI.SetActive(false);
        optionUI.SetActive(true);
    }

    public void WhenButtonBackClickOnOption()
    {
        optionUI.SetActive(false);
        pauseUI.SetActive(true);
    }

    public void WhenButtonToDesktopClick()
    {
        Application.Quit();
    }

    public void WhenButtonToMainMenuClick()
    {
        int numberOfMenuScene = 0;
        SceneManager.LoadScene(numberOfMenuScene);
    }
}
