using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    public event Action<float> PressedMoveKey;
    public event Action StopPressedMoveKey;
    public event Action ClickedJumpButton;

    private void Update()
    {
        ReadKeys();
    }

    private void ReadKeys()
    {
        float step = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(KeyCode.W))
        {
            ClickedJumpButton?.Invoke();
        }
        if (step < 0f || step > 0f)
        {
            PressedMoveKey?.Invoke(step);
        }
        else
        {
            StopPressedMoveKey?.Invoke();    
        }
    }
}
