using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "PlayerSO", order = 2)]
public class PlayerSO : ScriptableObject
{
    [SerializeField] public int currentFloor = 1;
    [SerializeField] public int currentplayerLevel = 1;
    [SerializeField] public int currentLevelExperience;
    [SerializeField] public int playerBaseAttackDamage = 2;
    [SerializeField] public int maxPlayerLevelExperiencePerLevel = 100;
    [SerializeField] public string currentWeapon_Lefthand;
    [SerializeField] public string currentWeapon_Righthand;
    [SerializeField] public Sprite weaponIcon_Left;
    [SerializeField] public Sprite weaponIcon_Right;
    [SerializeField] public int playerBaseHealth = 100;
    [SerializeField] public int playerBaseMana = 100;
    [SerializeField] public int currentHealth = 100;
    [SerializeField] public int currentMana = 100;

}
