using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerComeToArea : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Boss_Script boss_Script;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            StartCoroutine(boss_Script.DoDialog());
        }
    }
}
