using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGameObjectType_Item : GetGameObjectType
{
    [SerializeField] GameObject ItemPrefab;
    [SerializeField] CheckOtherCollider checkOtherCollider;
    public override void SetType(Collider2D collider)
    {
        if (collider.gameObject == ItemPrefab)
        {
            checkOtherCollider.isOnTriggerEnter2D = true;
            checkOtherCollider.currentItemType = ItemPrefab.name;
        }
    }
}
