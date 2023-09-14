using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAction : KeyCode_F_Action
{
    [SerializeField] GameObject chestPrefab;

    [Header("item list")]
    [SerializeField] itemSO key;
    [SerializeField] itemSO monster;
    [SerializeField] itemSO salt;
    public override void F_Action(string type)
    {
        int randomItemIndex = ChestManager.Instance.GetRandomItem();
        if (type == chestPrefab.name)
        {
            if (ChestManager.Instance.ItemLists[randomItemIndex] == key)
            {
                GameManager.Instance.isGetKey = true;
                Debug.Log("getKey Alr");
            }
            else if (ChestManager.Instance.ItemLists[randomItemIndex] == monster)
            {

            }
            else
            {
                //ต้องทำระบบเพิ่มความน่าจะเป็นหากเปิดได้ของชิ้นอื่น
                Debug.Log("getSalt");
            }
        }
    }
}
