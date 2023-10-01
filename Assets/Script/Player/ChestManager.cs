using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChestManager : Singleton<ChestManager> 
{
    [SerializeField] public int maxAmountOfChest;
    [SerializeField] List<itemSO> itemLists = new List<itemSO>();
    public List<itemSO> ItemLists => itemLists;

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
