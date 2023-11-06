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
    [SerializeField] ChestManager chestManager;

    [Header("For test")]
    [SerializeField] GameObject getkeyText;

    [Header("item list")]
    [SerializeField] itemSO key;
    [SerializeField] itemSO monster;
    [SerializeField] itemSO weapon;
    [SerializeField] itemSO salt;

    void Start()
    {
        int thisChestCount = 1;
        chestManager.maxAmountOfChest += thisChestCount;
        checkOtherCollider.gameObjectType.Add(thisChest);
        checkOtherCollider.keyCode_F_Actions.Add(thisChestAction);
    }
    public override void F_Action(string type)
    {
        int numberOfLastChest = 1;
        int randomItemIndex = ChestManager.Instance.GetRandomItem();
        if (chestManager.maxAmountOfChest == numberOfLastChest && GameManager.Instance.isGetKey == false && GameManager.Instance.isMonsterSpawn == false && type == chestPrefab.name)
        {
            GameManager.Instance.isGetKey = true;
            UIGetKey.Instance.GetKeyText();
            Debug.Log("getKey Alr");
            Destroy(chestPrefab);
            return;
        }

        if (type == chestPrefab.name && GameManager.Instance.isMonsterSpawn == false)
        {
            while (ChestManager.Instance.ItemLists[randomItemIndex] == key && GameManager.Instance.isGetKey == true)
            {
                randomItemIndex = ChestManager.Instance.GetRandomItem();
            }

            if (ChestManager.Instance.ItemLists[randomItemIndex] == key )
            {
                GameManager.Instance.isGetKey = true;
                UIGetKey.Instance.GetKeyText();
                Debug.Log("getKey Alr");
                Destroy(chestPrefab);
            }
            else if (ChestManager.Instance.ItemLists[randomItemIndex] == monster)
            {
                Debug.Log("Monster");
                StartCoroutine(monsterSpawnDelay());
                
            }
            else if (ChestManager.Instance.ItemLists[randomItemIndex] == weapon)
            {
                Debug.Log("Weapon");
                WeaponDrop.Instance.dropWeapon(gameObject.transform);
                Destroy(chestPrefab);
            }
            else if (ChestManager.Instance.ItemLists[randomItemIndex] == salt)
            {
                Debug.Log("getSalt");
                Destroy(chestPrefab);
            }
        }
    }
    private void OnDestroy()
    {
        int numberOfChestUse = 1;
        GameManager.Instance.isMonsterSpawn = false;
        checkOtherCollider.gameObjectType.Remove(thisChest);
        checkOtherCollider.keyCode_F_Actions.Remove(thisChestAction);
        chestManager.maxAmountOfChest -= numberOfChestUse;
    }

    IEnumerator monsterSpawnDelay()
    {
        GameManager.Instance.isMonsterSpawn = true;
        yield return new WaitForSeconds(GameManager.Instance.monsterDelaySpawn);
        float minAmountOfMonsterIndex = 0;
        float maxAmountOfMonsterIndex = monsterSpawn.Count;
        float randomMonsterIndex = Random.Range(minAmountOfMonsterIndex, maxAmountOfMonsterIndex);
        monsterSpawn[(int)randomMonsterIndex].SpawnMonster(chestPrefab.transform.position);
        Destroy(chestPrefab);
    }
}
