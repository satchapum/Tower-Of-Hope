using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGameObjectType_Chest : GetGameObjectType
{
    [SerializeField] GameObject chestPrefab;
    [SerializeField] CheckOtherCollider checkOtherCollider;
    public override void SetType(Collider2D collider)
    {
        if (collider.gameObject == chestPrefab)
        {
            checkOtherCollider.isOnTriggerEnter2D = true;
            checkOtherCollider.currentItemType = chestPrefab.name;
        }
    }
}
