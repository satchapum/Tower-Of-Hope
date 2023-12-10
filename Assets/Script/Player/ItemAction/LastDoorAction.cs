using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LastDoorAction : KeyCode_F_Action
{
    [SerializeField] int timeToShowKeyPic;
    [SerializeField] GameObject endCreditSceneUI;
    [SerializeField] GameObject player;
    [SerializeField] GameObject loadSceneCanvas;
    [SerializeField] GetGameObjectType_Door thisDoor;
    [SerializeField] CheckOtherCollider checkOtherCollider;
    [SerializeField] KeyCode_F_Action thisDoorAction;
    [SerializeField] GameObject keyPicture;
    [SerializeField] GameObject doorPrefab;

    [SerializeField] bool IsShowKey = false;
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
            if (GameManager.Instance.IsFinalBossDie == true)
            {
                player.SetActive(false);
                endCreditSceneUI.SetActive(true);
            }
        }

    }

    public void Update()
    {
        if (GameManager.Instance.IsFinalBossDie == true && IsShowKey == false)
        {
            IsShowKey = true;
            keyPicture.SetActive(true);
            StartCoroutine(ShowKeyDelay());
        }
    }

    IEnumerator ShowKeyDelay()
    {
        yield return new WaitForSeconds(timeToShowKeyPic);
        keyPicture.SetActive(false);
    }
}