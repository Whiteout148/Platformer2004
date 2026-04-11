using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const int AttackMouseButton = 0; 

    private const KeyCode JumpButton = KeyCode.W;
    private const KeyCode DefenceButton = KeyCode.E;

    public event Action<float> PressedMoveKey;
    public event Action StopPressedMoveKey;
    public event Action PressedJumpButton;
    public event Action StartPressedBlockButton;
    public event Action StopPressedBlockButton;
    public event Action PressedAttackButton;
    public event Action PressedDefenceButton;

    private void Update()
    {
        ReadKeys();
    }

    private void ReadKeys()
    {
        float direction = Input.GetAxis(Horizontal);

        if (Input.GetMouseButtonDown(AttackMouseButton))
        {
            PressedAttackButton?.Invoke();
        }

        if (Input.GetKeyDown(DefenceButton))
        {
            PressedDefenceButton?.Invoke();
        }

        if (Input.GetKeyDown(JumpButton))
        {
            PressedJumpButton?.Invoke();
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
