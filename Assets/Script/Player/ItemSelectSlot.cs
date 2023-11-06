using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectSlot : MonoBehaviour
{
    [SerializeField] GameObject uiSlotWeaponSelect;
    public void WhenCloseButtonInSelectSlotClick()
    {
        Time.timeScale = 1;
        uiSlotWeaponSelect.SetActive(false);
    } 
}
