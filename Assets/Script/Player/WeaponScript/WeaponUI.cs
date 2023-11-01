using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : Singleton<WeaponUI>
{
    [SerializeField] Image leftHandUI;
    [SerializeField] Image rightHandUI;

    private void Start()
    {
        leftHandUI.sprite = GameManager.Instance.weaponIcon_Left;
        rightHandUI.sprite = GameManager.Instance.weaponIcon_Right;
    }
    public void SetUILeftHand(Sprite weaponIcon)
    {
        leftHandUI.sprite = weaponIcon;
        GameManager.Instance.weaponIcon_Left = weaponIcon;
    }

    public void SetUIRightHand(Sprite weaponIcon)
    {
        rightHandUI.sprite = weaponIcon;
        GameManager.Instance.weaponIcon_Right = weaponIcon;
    }
}
