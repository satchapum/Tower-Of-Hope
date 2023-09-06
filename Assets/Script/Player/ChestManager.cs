using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChestManager : Singleton<ChestManager> 
{
    [SerializeField] public List<itemList> itemLists = new List<itemList>();
    List<itemList> ItemLists => itemLists;

    public List<itemList> setList()
    {
        return itemLists;
    }
    public int GetRandomItem()
    {
        float random = Random.Range(0f, 1f);
        float numForAdding = 0;
        float totalPercentages = 0;
        for (int numberOfItem = 0; numberOfItem < itemLists.Count; numberOfItem++)
        {
            totalPercentages += ItemLists[numberOfItem].probabilityPercentage;
        }

        for (int numberOfItem = 0; numberOfItem < itemLists.Count; numberOfItem++)
        {
            if (ItemLists[numberOfItem].probabilityPercentage / totalPercentages + numForAdding >= random)
            {
                return numberOfItem;
            }
            else
            {
                numForAdding += ItemLists[numberOfItem].probabilityPercentage / totalPercentages;
            }
        }
        return 0;
    }

}
//ใช้สำหรับการเพิ่มข้อมูลของในกล่องอาจเพิ่มตัวแปรที่เก็บได้เช่นประเภทเป็น item หรือ monster
[Serializable]
public class itemList
{
    public Sprite itemImage;
    public string name;
    public float probabilityPercentage;
}
