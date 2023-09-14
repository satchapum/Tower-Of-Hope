using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : KeyCode_F_Action
{
    [SerializeField] GameObject doorPrefab;
    [SerializeField] CheckOtherCollider checkOtherCollider;
    [SerializeField] GetGameObjectType_Door thisDoor;
    [SerializeField] KeyCode_F_Action thisDoorAction;

    void Start()
    {
        checkOtherCollider.gameObjectType.Add(thisDoor);
        checkOtherCollider.keyCode_F_Actions.Add(thisDoorAction);
    }
    public override void F_Action(string type)
    {
        if (type == doorPrefab.name)
        {
            if (GameManager.Instance.isGetKey == true)
            {
                Debug.Log("Load New Scene Floor");
                checkOtherCollider.gameObjectType.Remove(thisDoor);
                checkOtherCollider.keyCode_F_Actions.Remove(thisDoorAction);
            }
            else
            {
                Debug.Log("No key");
            }
        }
    }
}
