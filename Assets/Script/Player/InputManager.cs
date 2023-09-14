using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] string horizontalkey = "Horizontal";
    [SerializeField] string verticalkey = "Vertical";

    public float HorizontalInput => horizontalInput;
    float horizontalInput;
    public float VerticalInput => verticalInput;
    float verticalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis(horizontalkey);
        verticalInput = Input.GetAxis(verticalkey);
    }
}
