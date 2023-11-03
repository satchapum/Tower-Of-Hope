﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CheckOtherCollider : Singleton<CheckOtherCollider>
{
    [SerializeField] public bool isOnTriggerEnter2D;
    [SerializeField] public string currentItemType;
    [SerializeField] public GameObject pressFText;

    public List<KeyCode_F_Action> keyCode_F_Actions;
    public List<GetGameObjectType> gameObjectType;

    private void Start()
    {
        SetToBackGround();
    }

    void Update()
    {
        if (isOnTriggerEnter2D == true && GameManager.Instance.currentMonsterCount == 0 && GameManager.Instance.isMonsterSpawn == false)
        {
            pressFText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                int firstNumberOfAction = 0;
                for (int numberOfAction = firstNumberOfAction; numberOfAction < gameObjectType.Count; numberOfAction++)
                {
                    keyCode_F_Actions[numberOfAction].F_Action(currentItemType);
                }
            }
        }
    }

    void SetToBackGround()
    {
        isOnTriggerEnter2D = false;
        currentItemType = "Background";
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        int firstNumberOfItem = 0;
        for (int numberOfItem = firstNumberOfItem; numberOfItem < gameObjectType.Count; numberOfItem++)
        {
            gameObjectType[numberOfItem].SetType(collider);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        pressFText.SetActive(false);
        SetToBackGround();
    }
}
