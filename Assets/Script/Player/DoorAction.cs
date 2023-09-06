using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : KeyCode_F_Action
{
    [SerializeField] GameObject doorPrefab;
    public override void F_Action(string type)
    {
        if (type == doorPrefab.name)
        {
            if (GameManager.Instance.isGetKey == true)
            {
                Debug.Log("Load New Scene Floor");
            }
            else
            {
                Debug.Log("No key");
            }
        }
    }
}
