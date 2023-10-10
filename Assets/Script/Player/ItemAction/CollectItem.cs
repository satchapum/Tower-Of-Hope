using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : KeyCode_F_Action
{
    [SerializeField] AttackSystem attackSystem;
    [SerializeField] GetGameObjectType_Item thisItem;
    [SerializeField] KeyCode_F_Action thisItemAction;
    [SerializeField] CheckOtherCollider checkOtherCollider;
    [SerializeField] GameObject selectReplaceSlot;
    [Header("For heal potion")]
    [SerializeField] int healAmount;
    [Header("For Mana potion")]
    [SerializeField] int manaAmount;

    void Start()
    {
        checkOtherCollider.gameObjectType.Add(thisItem);
        checkOtherCollider.keyCode_F_Actions.Add(thisItemAction);
    }

    public override void F_Action(string type)
    {
        
        if (type == gameObject.name)
        {
            if (gameObject.GetComponent<ItemInfo>().name == "Health")
            {
                Player_health.Instance.healPlayerHealt(healAmount);
                Destroy(gameObject);
            }
            else if (gameObject.GetComponent<ItemInfo>().name == "Mana")
            {
                Player_Mana.Instance.RePlayerMana(manaAmount);
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        checkOtherCollider.gameObjectType.Remove(thisItem);
        checkOtherCollider.keyCode_F_Actions.Remove(thisItemAction);
    }
}
