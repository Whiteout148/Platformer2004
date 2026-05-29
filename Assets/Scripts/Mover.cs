using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimationShower))]
[RequireComponent (typeof(Stunner))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _step = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Rigidbody2D _rigidbody;

    private bool _isMove = false;
    private Coroutine _moveCoroutine;
    private float _direction;
    private IMoveAnimater _animater;
    private IStunneable _stunner;

    public event Action StartedMove;
    public event Action EndedMoved;

    private void Awake()
    {
        _stunner = GetComponent<Stunner>();
        _animater = GetComponent<AnimationShower>();
    }

    public void Move(float direction)
    {
        if (_stunner.IsStunn)
        {
            StopMove();

            return;
        }

        StartedMove?.Invoke();
        _isMove = true;
        _animater.PlayMove();

        if (_moveCoroutine == null)
        {
            _moveCoroutine = StartCoroutine(MoveDirection(direction));
        }
    }

    public void StopMove()
    {
        if (_stunner.IsStunn)
            return;

        EndedMoved?.Invoke();
        _isMove = false;
        _animater.StopPlayMove();

        _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y);

        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }
    }

    private IEnumerator MoveDirection(float direction)
    {
        float currentStep;

        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

        while (_isMove)
        {
            if (direction < 0)
            {
                currentStep = -_step;
            }
            else
            {
                currentStep = _step;
            }

            _rigidbody.velocity = new Vector2(currentStep * _speed, _rigidbody.velocity.y);

            yield return waitForFixedUpdate;
        }
    }
}
