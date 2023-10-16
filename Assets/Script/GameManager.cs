using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    [Header("Game Setting")]
    [SerializeField] public bool isGetKey;
    [SerializeField] public int currentMonsterCount;

    [Header("Player Setting")]
    [SerializeField] public int currentplayerLevel;
    [SerializeField] public int playerBaseAttackDamage;
    [SerializeField] public int palyerBaseHealth;
    [SerializeField] public int playerBaseMana;

}
