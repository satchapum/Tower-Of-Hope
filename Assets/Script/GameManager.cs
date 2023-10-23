using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    [Header("Game Setting")]
    [SerializeField] public bool isGetKey;
    [SerializeField] public int currentMonsterCount;
    [SerializeField] public int currentFloor = 1;
    [SerializeField] public float monsterDelaySpawn = 2;
    [SerializeField] public bool isMonsterSpawn = false;

    [Header("Player Setting")]
    [SerializeField] public int currentplayerLevel = 1;
    [SerializeField] public int playerBaseAttackDamage = 5;
    [SerializeField] public int playerBaseHealth = 100;
    [SerializeField] public int playerBaseMana = 100;
    [SerializeField] public int maxPlayerLevelExperiencePerLevel = 100;

}
