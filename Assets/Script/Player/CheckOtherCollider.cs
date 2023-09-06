using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckOtherCollider : MonoBehaviour
{
    [SerializeField] bool isOnTriggerEnter2D;
    [SerializeField] string currentItemType;
    private void Start()
    {
        SetToBackGround();
    }
    void Update()
    {
        if (isOnTriggerEnter2D == true)
        {
            //ใช้สำหรับการกดปุ่มและสั่งให้ทำคำสั่งโดยยึดตัว Type ของที่ชน
            if (Input.GetKeyDown(KeyCode.F) && currentItemType == TagManager.Instance.chestTag)//ระบุประเภทของเวลาใช้เพื่อให้ไม่ชนกัน
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
            else if (Input.GetKeyDown(KeyCode.F) && currentItemType == TagManager.Instance.doorTag)
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
            //อาจเพิ่มของประเภทการเก็บของได้การไปด่านต่อไปได้
            /*else if (Input.GetKeyDown(KeyCode.F) && currentItemType == "   ")
            {

            }*/
        }
    }
    void SetToBackGround()
    {
        isOnTriggerEnter2D = false;
        currentItemType = "Background";
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(TagManager.Instance.chestTag))
        {
            isOnTriggerEnter2D = true;
            currentItemType = TagManager.Instance.chestTag;
        }
        else if (collider.CompareTag(TagManager.Instance.doorTag))
        {
            isOnTriggerEnter2D = true;
            currentItemType = TagManager.Instance.doorTag;
        }
        //ใช้เพิ่มตัวของที่ชนเข้ามารับประเภทของของชิ้นนั้น
        /*else if ()
        {

        }*/
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        SetToBackGround();
    }
}
