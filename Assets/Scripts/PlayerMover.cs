using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : Mover
{
    [SerializeField] private InputReader _reader;

    private void OnEnable()
    {
        _reader.PressedMoveKey += Move;
        _reader.StopPressedMoveKey += StopMove;
        _reader.ClickedJumpButton += Jumper.Jump;
    }

    private void OnDisable()
    {
        _reader.PressedMoveKey -= Move;
        _reader.StopPressedMoveKey -= StopMove;
        _reader.ClickedJumpButton -= Jumper.Jump;
    }

    public virtual void Move(float step)
    {
        base.Move(step);
        IsMove = true;

        if (step < 0)
        {
            step -= Step;
            MoveRight(step);
        }
        else if (step > 0)
        {
            step += Step;
            MoveLeft(step);
        }
    }

    public override void StopMove()
    {
        base.StopMove();

        if (MoveCoroutine != null)
        {
            StopCoroutine(MoveCoroutine);
            MoveCoroutine = null;
        }

        IsMove = false;
    }

    public override Vector3 GetScale(float step)
    {
        Vector3 direction;

        if (step < 0)
        {
            direction = ScaleOnGoRight;
        }
        else if (step > 0)
        {
            direction = ScaleOnGoLeft;
        }

        return base.GetScale(step);
    }

    private void MoveRight(float step)
    {
        if (MoveCoroutine == null)
        {
            transform.localScale = ScaleOnGoRight;
            MoveCoroutine = StartCoroutine(DirectionMove(step));
        }
    }

    private void MoveLeft(float step)
    {
        if (MoveCoroutine == null)
        {
            transform.localScale = ScaleOnGoLeft;
            MoveCoroutine = StartCoroutine(DirectionMove(step));
        }
    }

    private IEnumerator DirectionMove(float step)
    {
        while (IsMove)
        {
            yield return null;

            transform.position += new Vector3(step, 0f, 0f) * Speed * Time.deltaTime;
        }
    }
}
