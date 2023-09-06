using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAction : KeyCode_F_Action
{
    [SerializeField] GameObject chestPrefab;
    public override void F_Action(string type)
    {
        if (type == chestPrefab.name)
        {
            if (ChestManager.Instance.itemLists[ChestManager.Instance.GetRandomItem()].name == "Key")
            {
                GameManager.Instance.isGetKey = true;
                Debug.Log("getKey Alr");
            }
            else
            {
                //ต้องทำระบบเพิ่มความน่าจะเป็นหากเปิดได้ของชิ้นอื่น
                Debug.Log("getSalt");
            }
        }
    }
}
