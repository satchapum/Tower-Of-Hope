using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : Singleton<WeaponUI>
{
    [SerializeField] Image leftHandUI;
    [SerializeField] Image rightHandUI;

    public void SetUILeftHand(Sprite weaponIcon)
    {
        leftHandUI.sprite = weaponIcon;
    }

    public void SetUIRightHand(Sprite weaponIcon)
    {
        rightHandUI.sprite = weaponIcon;
    }
}
