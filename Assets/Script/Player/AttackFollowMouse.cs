using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFollowMouse : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] GameObject attackArea;
    private void Start()
    {
        attackArea.SetActive(false);
    }

    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - attackArea.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        attackArea.transform.rotation = Quaternion.Slerp(attackArea.transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }

}
