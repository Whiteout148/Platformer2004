using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardsMover : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Rotater _rotater;

    private IDirectionSetter _directionSetter;
    private Coroutine _moveingCoroutine;
    private bool _isRunning = false;

    private void Awake()
    {
        _directionSetter = _rotater;
    }

    public void MoveToTarget(Transform target)
    {
        float pointDirection;

        if (target.position.x < transform.position.x)
        {
            pointDirection = -1f;
        }
        else
        {
            pointDirection = 1f;
        }

        _directionSetter.SetDirection(pointDirection);
        _mover.Move(pointDirection);
    }
    
    public void StopMoveToTarget()
    {
        _mover.StopMove();
    }

    public bool IsOnPoint(Transform target)
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) < 0.1f)
        {
            _mover.StopMove();

            return true;
        }

        return false;
    }
}
