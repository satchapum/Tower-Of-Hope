using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWeapon : KeyCode_F_Action
{
    [SerializeField] GameObject thisGameObject;
    [SerializeField] AttackSystem attackSystem;
    [SerializeField] GetGameObjectType_Item thisItem;
    [SerializeField] KeyCode_F_Action thisItemAction;
    [SerializeField] CheckOtherCollider checkOtherCollider;
    [SerializeField] GameObject selectReplaceSlot;
    [SerializeField] ItemInfo ItemInfo;

    void Start()
    {
        checkOtherCollider.gameObjectType.Add(thisItem);
        checkOtherCollider.keyCode_F_Actions.Add(thisItemAction);
    }

    private void Update()
    {
        int slot_1 = 1;
        int slot_2 = 2;
        if (attackSystem.numberSlotSelect != 0)
        {
            if (CheckOtherCollider.Instance.currentItemType == thisGameObject.name)
            {
                if (attackSystem.numberSlotSelect == slot_1)
                {
                    GameManager.Instance.currentWeapon_Lefthand = ItemInfo.name;
                    attackSystem.numberSlotSelect = 0;

                    WeaponUI.Instance.SetUILeftHand(ItemInfo.iconWeapon);

                    selectReplaceSlot.gameObject.SetActive(false);
                    Destroy(thisGameObject);
                }
                else if (attackSystem.numberSlotSelect == slot_2)
                {
                    GameManager.Instance.currentWeapon_Righthand = ItemInfo.name;
                    attackSystem.numberSlotSelect = 0;

                    WeaponUI.Instance.SetUIRightHand(ItemInfo.iconWeapon);

                    selectReplaceSlot.gameObject.SetActive(false);
                    Destroy(thisGameObject);
                }
            }
        }
    }

    public override void F_Action(string type)
    {
        
        if (type == thisGameObject.name)
        {
            if (GameManager.Instance.currentWeapon_Lefthand == "")
            {
                WeaponUI.Instance.SetUILeftHand(ItemInfo.iconWeapon);

                GameManager.Instance.currentWeapon_Lefthand = ItemInfo.name;
                Destroy(thisGameObject);
            }
            else if (GameManager.Instance.currentWeapon_Righthand == "")
            {
                WeaponUI.Instance.SetUIRightHand(ItemInfo.iconWeapon);

                GameManager.Instance.currentWeapon_Righthand = ItemInfo.name;
                Destroy(thisGameObject);
            }
            else
            {
                selectReplaceSlot.gameObject.SetActive(true);
            }
            
        }
    }

    private void OnDestroy()
    {
        checkOtherCollider.gameObjectType.Remove(thisItem);
        checkOtherCollider.keyCode_F_Actions.Remove(thisItemAction);
    }
}
