using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDrop : Singleton<WeaponDrop>
{
    [SerializeField] List<ItemInfo> itemList = new List<ItemInfo>();

    public List<ItemInfo> ItemList => itemList;
    public void dropWeapon(Transform transformLastMonster)
    {
        int numberOfItem =  GetRandomItem();
        foreach (var item in itemList)
        {
            if (itemList[numberOfItem] == item)
            {
                var thisItem = Instantiate(item, transformLastMonster.position,Quaternion.identity);
                thisItem.gameObject.SetActive(true);
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
