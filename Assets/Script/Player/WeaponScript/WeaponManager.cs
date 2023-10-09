using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class WeaponManager : MonoBehaviour
{
    public abstract float attackCooldown { get; set; }
}
