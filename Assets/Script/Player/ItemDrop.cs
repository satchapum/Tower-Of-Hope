using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : Singleton<ItemDrop>
{
    [SerializeField] int numberOfAdding;
    [SerializeField] List<ItemInfo> itemList = new List<ItemInfo>();

    public List<ItemInfo> ItemList => itemList;
    public void dropItem(Transform transformLastMonster)
    {
        int numberOfItem =  GetRandomItem();
        foreach (var item in itemList)
        {
            if (itemList[numberOfItem] == item)
            {
                GameObject thisItem = Instantiate(item.gameObject, transformLastMonster.position,Quaternion.identity);
                thisItem.name = item.name+'('+numberOfAdding+')';
                thisItem.gameObject.SetActive(true);
                numberOfAdding++;
            }
        }
    }

    public int GetRandomItem()
    {
        float random = Random.Range(0f, 1f);
        float numForAdding = 0;
        float totalPercentages = 0;
        for (int numberOfItem = 0; numberOfItem < itemList.Count; numberOfItem++)
        {
            totalPercentages += ItemList[numberOfItem].probabilityPercentage;
        }

        for (int numberOfItem = 0; numberOfItem < itemList.Count; numberOfItem++)
        {
            if (ItemList[numberOfItem].probabilityPercentage / totalPercentages + numForAdding >= random)
            {
                return numberOfItem;
            }
            else
            {
                numForAdding += ItemList[numberOfItem].probabilityPercentage / totalPercentages;
            }
        }
        return 0;
    }
}
