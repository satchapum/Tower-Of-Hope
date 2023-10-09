using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillManager : MonoBehaviour
{
    public abstract Sprite skill_Icon { get; set; }
    public abstract string current_key { get; set; }
    public abstract int coolDownTime { get; set; }
    public abstract Transform attackPositon { get; set; }
    public abstract string targetWeapon { get; set; }
    public abstract void CreateSkill();
}
