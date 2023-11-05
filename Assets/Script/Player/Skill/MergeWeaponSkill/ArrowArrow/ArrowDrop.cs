using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDrop : MonoBehaviour
{
    [SerializeField] Transform currentTarget;
    [SerializeField] public float arrowDropSpeed;
    private void Update()
    { 
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, arrowDropSpeed * Time.deltaTime);
    }
}
