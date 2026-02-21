using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Rotater _rotater;
    [SerializeField] private InputReader _reader;

    private void OnEnable()
    {
        _reader.PressedMoveKey += _mover.Move;
        _reader.PressedMoveKey += _rotater.SetDirection;
        _reader.StopPressedMoveKey += _mover.StopMove;
        _reader.ClickedJumpButton += _jumper.Jump;
    }

    private void OnDisable()
    {
        _reader.PressedMoveKey -= _mover.Move;
        _reader.PressedMoveKey -= _rotater.SetDirection;
        _reader.StopPressedMoveKey -= _mover.StopMove;
        _reader.ClickedJumpButton -= _jumper.Jump;
    }
}
