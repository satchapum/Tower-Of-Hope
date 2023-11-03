using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectSlot : MonoBehaviour
{
    [SerializeField] GameObject uiSlotWeaponSelect;
    public void WhenCloseButtonInSelectSlotClick()
    {
        uiSlotWeaponSelect.SetActive(false);
    } 
}
