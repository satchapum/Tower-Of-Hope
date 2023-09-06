using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager : Singleton<TagManager>
{
    //เพิ่ม Tag ในนี้ด้วยเรียนใช้ใน CheckOtherCollider และเพิ่มใน Tag editor unity ด้วย
    public string chestTag = "Chest";
    public string doorTag = "Door";
}
