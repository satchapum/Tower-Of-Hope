using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] string horizontalkey = "Horizontal";
    [SerializeField] string verticalkey = "Vertical";
    [SerializeField] KeyCode MouseLeft;
    [SerializeField] KeyCode MouseRight;
    [SerializeField] KeyCode KeyQ;
    [SerializeField] KeyCode KeyE;
    [SerializeField] KeyCode KeyX;

    public float HorizontalInput => horizontalInput;
    float horizontalInput;
    public float VerticalInput => verticalInput;
    float verticalInput;

    public bool mouseLeftDown { get; private set; }
    public bool mouseRightDown { get; private set; }

    public bool KeyQ_Down { get; private set; }

    public bool KeyE_Down { get; private set; }

    public bool KeyX_Down { get; private set; }


    private void Update()
    {
        horizontalInput = Input.GetAxis(horizontalkey);
        verticalInput = Input.GetAxis(verticalkey);

        mouseLeftDown = Input.GetKey(MouseLeft);
        mouseRightDown = Input.GetKey(MouseRight);

        KeyQ_Down = Input.GetKey(KeyQ);
        KeyE_Down = Input.GetKey(KeyE);
        KeyX_Down = Input.GetKey(KeyX);
    }
}
