using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const KeyCode JumpButton = KeyCode.W; 

    public event Action<float> PressedMoveKey;
    public event Action StopPressedMoveKey;
    public event Action ClickedJumpButton;

    private void Update()
    {
        ReadKeys();
    }

    private void ReadKeys()
    {
        float direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(JumpButton))
        {
            ClickedJumpButton?.Invoke();
        }
        if (!Mathf.Approximately(direction, 0))
        {
            PressedMoveKey?.Invoke(direction);
        }
        else
        {
            StopPressedMoveKey?.Invoke();    
        }
    }
}
