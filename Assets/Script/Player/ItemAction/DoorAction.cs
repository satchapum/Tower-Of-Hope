using System.Collections;
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
    [SerializeField] int numberOfscene = 0;

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
        checkOtherCollider.gameObjectType.Remove(thisDoor);
        checkOtherCollider.keyCode_F_Actions.Remove(thisDoorAction);
        yield return new WaitForSeconds(delayLoadTime);
        loadSceneCanvas.SetActive(true);
        SceneManager.LoadScene(numberOfscene);
    }
    IEnumerator DeleteDelay()
    {
        loadSceneCanvas.SetActive(true);
        yield return new WaitForSeconds(delayCloseTime);
        loadSceneCanvas.GetComponent<TMP_Text>().text = "No key!!";
    }
}
