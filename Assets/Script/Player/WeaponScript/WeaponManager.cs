using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponManager : MonoBehaviour
{
    public abstract Image weaponIcon { get; set; }
    public abstract float attackDelay { get; set; }
}
