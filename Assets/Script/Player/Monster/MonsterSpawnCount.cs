using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnCount : MonoBehaviour
{
    [SerializeField] ArrowMagicWand_Skill arrowMagic;

    private void Start()
    {
        arrowMagic.all_Monster_List.Add(gameObject.GetComponent<Monster>());
    }
    private void OnDestroy()
    {
        arrowMagic.all_Monster_List.Remove(gameObject.GetComponent<Monster>());
    }
}
