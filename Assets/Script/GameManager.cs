using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    [Header("Game Setting")]
    [SerializeField] public bool isGetKey;
    [SerializeField] public int currentMonsterCount;
    [SerializeField] public int currentFloor;
    [SerializeField] public float monsterDelaySpawn = 2;
    [SerializeField] public bool isMonsterSpawn = false;
    [SerializeField] public bool IsTutorial = false;

    [Header("Player Setting")]
    [SerializeField] public int currentplayerLevel;
    [SerializeField] public int currentLevelExperience;
    [SerializeField] public int playerBaseAttackDamage;
    [SerializeField] public int playerBaseHealth;
    [SerializeField] public int playerBaseMana;
    [SerializeField] public int maxPlayerLevelExperiencePerLevel;
    [SerializeField] public string currentWeapon_Lefthand;
    [SerializeField] public string currentWeapon_Righthand;
    [SerializeField] public Sprite weaponIcon_Left;
    [SerializeField] public Sprite weaponIcon_Right;
    [SerializeField] public int currentHealth;
    [SerializeField] public int currentMana;

    [Header("Player Setting")]
    [SerializeField] PlayerSO playerData;

    private void Awake()
    {
        currentFloor = playerData.currentFloor;
        currentplayerLevel = playerData.currentplayerLevel;
        currentLevelExperience = playerData.currentLevelExperience;
        playerBaseAttackDamage = playerData.playerBaseAttackDamage;
        playerBaseHealth = playerData.playerBaseHealth;
        playerBaseMana = playerData.playerBaseMana;
        maxPlayerLevelExperiencePerLevel = playerData.maxPlayerLevelExperiencePerLevel;
        currentWeapon_Lefthand = playerData.currentWeapon_Lefthand;
        currentWeapon_Righthand = playerData.currentWeapon_Righthand;
        weaponIcon_Left = playerData.weaponIcon_Left;
        weaponIcon_Right = playerData.weaponIcon_Right;
        currentHealth = playerData.currentHealth;
        currentMana = playerData.currentMana;
    }

    public void ResetData()
    {
        playerData.currentFloor = 1;
        playerData.currentplayerLevel = 1;
        playerData.currentLevelExperience = 0;
        playerData.playerBaseAttackDamage = 2;
        playerData.playerBaseHealth = 100;
        playerData.playerBaseMana = 100;
        playerData.maxPlayerLevelExperiencePerLevel = 100;
        playerData.currentWeapon_Lefthand = "";
        playerData.currentWeapon_Righthand = "";
        playerData.weaponIcon_Left = null;
        playerData.weaponIcon_Right = null;
        playerData.currentHealth = 100;
        playerData.currentMana = 100;
    }

    public void SetPlayerDataWhenChangeFloor()
    {
        playerData.currentFloor = currentFloor;
        playerData.currentplayerLevel = currentplayerLevel;
        playerData.currentLevelExperience = currentLevelExperience;
        playerData.playerBaseAttackDamage = playerBaseAttackDamage;
        playerData.playerBaseHealth = playerBaseHealth;
        playerData.playerBaseMana = playerBaseMana;
        playerData.maxPlayerLevelExperiencePerLevel = maxPlayerLevelExperiencePerLevel;
        playerData.currentWeapon_Lefthand = currentWeapon_Lefthand;
        playerData.currentWeapon_Righthand = currentWeapon_Righthand;
        playerData.weaponIcon_Left = weaponIcon_Left;
        playerData.weaponIcon_Right = weaponIcon_Right;
        playerData.currentHealth = currentMana;
        playerData.currentHealth = currentHealth;
    }
}
