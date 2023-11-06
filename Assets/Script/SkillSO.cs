using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "SkillSO", order = 3)]

public class SkillSO : ScriptableObject
{
    [SerializeField] public int damage;
    [SerializeField] public int manaCost;
    [SerializeField] public int CoolDownTime;
}
