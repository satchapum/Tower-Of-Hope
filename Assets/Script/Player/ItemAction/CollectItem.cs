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

    void Start()
    {
        checkOtherCollider.gameObjectType.Add(thisItem);
        checkOtherCollider.keyCode_F_Actions.Add(thisItemAction);
    }
    public override void F_Action(string type)
    {
        
        if (type == gameObject.name)
        {
            if (attackSystem.currentWeapon_Lefthand == "")
            {
                attackSystem.currentWeapon_Lefthand = gameObject.GetComponent<ItemInfo>().name;
            }
            else if (attackSystem.currentWeapon_Righthand == "")
            {
                attackSystem.currentWeapon_Righthand = gameObject.GetComponent<ItemInfo>().name;
            }
            else
            {
                selectReplaceSlot.gameObject.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
    IEnumerable selectSlotToRepalce()
    {
        var waitForButton = new WaitForUIButtons(yesButton, noButton);

        int slot_1 = 1;
        int slot_2 = 2;

        while (attackSystem.numberSlotSelect == 0)
        {
            if (attackSystem.numberSlotSelect == slot_1)
            {
                attackSystem.currentWeapon_Lefthand = gameObject.GetComponent<ItemInfo>().name;
                attackSystem.numberSlotSelect = 0;
                selectReplaceSlot.gameObject.SetActive(false);
            }
            else if (attackSystem.numberSlotSelect == slot_2)
            {
                attackSystem.currentWeapon_Righthand = gameObject.GetComponent<ItemInfo>().name;
                attackSystem.numberSlotSelect = 0;
                selectReplaceSlot.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnDestroy()
    {
        checkOtherCollider.gameObjectType.Remove(thisItem);
        checkOtherCollider.keyCode_F_Actions.Remove(thisItemAction);
    }
}
