using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAction : KeyCode_F_Action
{
    [SerializeField] List<Monster> monsterSpawn;
    [SerializeField] GameObject chestPrefab;
    [SerializeField] CheckOtherCollider checkOtherCollider;
    [SerializeField] GetGameObjectType_Chest thisChest;
    [SerializeField] KeyCode_F_Action thisChestAction;
    
    [Header("item list")]
    [SerializeField] itemSO key;
    [SerializeField] itemSO monster;
    [SerializeField] itemSO salt;
    void Start()
    {
        checkOtherCollider.gameObjectType.Add(thisChest);
        checkOtherCollider.keyCode_F_Actions.Add(thisChestAction);
    }
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
                Debug.Log("Monster");
                float minAmountOfMonsterIndex = 0;
                float maxAmountOfMonsterIndex = monsterSpawn.Count;
                float randomMonsterIndex = Random.Range(minAmountOfMonsterIndex, maxAmountOfMonsterIndex);
                monsterSpawn[(int)randomMonsterIndex].SpawnMonster(chestPrefab.transform.position);
            }
            else
            {
                //ต้องทำระบบเพิ่มความน่าจะเป็นหากเปิดได้ของชิ้นอื่น
                Debug.Log("getSalt");
            }
            checkOtherCollider.gameObjectType.Remove(thisChest);
            checkOtherCollider.keyCode_F_Actions.Remove(thisChestAction);
            Destroy(chestPrefab);
        }
    }
}
