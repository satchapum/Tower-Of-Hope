using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGameObjectType_Door : GetGameObjectType
{
    [SerializeField] GameObject doorPrefab;
    [SerializeField] CheckOtherCollider checkOtherCollider;
    public override void SetType(Collider2D collider)
    {
        if (collider.gameObject == doorPrefab)
        {
            checkOtherCollider.isOnTriggerEnter2D = true;
            checkOtherCollider.currentItemType = doorPrefab.name;
        }
    }
}
