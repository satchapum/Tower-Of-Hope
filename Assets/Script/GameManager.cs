using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    //จักการเกมพวก HUD
    [SerializeField] public bool isGetKey;
    [SerializeField] public int currentMonsterCount;

}
