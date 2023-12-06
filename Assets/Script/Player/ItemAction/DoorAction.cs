﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DoorAction : KeyCode_F_Action
{
    [SerializeField] GameObject doorPrefab;
    [SerializeField] CheckOtherCollider checkOtherCollider;
    [SerializeField] GetGameObjectType_Door thisDoor;
    [SerializeField] KeyCode_F_Action thisDoorAction;
    [SerializeField] GameObject loadSceneCanvas;
    [SerializeField] TMP_Text loadText;

    [SerializeField] float delayCloseTime = 1;
    [SerializeField] float delayLoadTime = 1;

    void Start()
    {
        loadSceneCanvas.SetActive(false);
        checkOtherCollider.gameObjectType.Add(thisDoor);
        checkOtherCollider.keyCode_F_Actions.Add(thisDoorAction);
    }
    public override void F_Action(string type)
    {
        if (type == doorPrefab.name)
        {
            if (GameManager.Instance.isGetKey == true)
            {
                GameManager.Instance.currentFloor++;
                GameManager.Instance.SetPlayerDataWhenChangeFloor();
                StartCoroutine(LoadSceneDelay());
            }
            else
            {
                StartCoroutine(DeleteDelay());
            }
        }
    }
    IEnumerator LoadSceneDelay()
    {
        loadSceneCanvas.SetActive(true);
        loadText.text = "FLOOR : " + (GameManager.Instance.currentFloor - 1);
        checkOtherCollider.gameObjectType.Remove(thisDoor);
        checkOtherCollider.keyCode_F_Actions.Remove(thisDoorAction);
        yield return new WaitForSeconds(delayLoadTime);
        loadSceneCanvas.SetActive(false);
        SceneManager.LoadScene(GameManager.Instance.currentFloor);
    }
    IEnumerator DeleteDelay()
    {
        loadSceneCanvas.SetActive(true);
        loadText.text = "No keyas";
        yield return new WaitForSeconds(delayCloseTime);
        loadSceneCanvas.SetActive(false);
    }
}
