using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearDrop : MonoBehaviour
{
    [SerializeField] Transform currentTarget;
    [SerializeField] public float spearDropSpeed;
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, spearDropSpeed * Time.deltaTime);
    }
}
