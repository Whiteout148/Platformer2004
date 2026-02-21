using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Rendering;

public class Mover : MonoBehaviour
{
    private const float _rightDirection = -0.001f;
    private const float _leftDirection = 0.001f;

    [SerializeField] private float _step = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Rigidbody2D _rigidbody;

    private bool _isMove = false;
    private Coroutine _moveCoroutine;
   
    public event Action StartMoved;
    public event Action EndMoved;

    public void Move(float direction)
    {
        StartMoved?.Invoke();
        _isMove = true;

        if (_moveCoroutine == null)
        {
            _moveCoroutine = StartCoroutine(DirectionMove(direction));
        }
    }

    public void StopMove()
    {
        EndMoved?.Invoke();
        _isMove = false;

        _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y);

        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }
    }

    private IEnumerator DirectionMove(float direction)
    {
        float currentStep;

        if (direction < 0)
        {
            currentStep = -_step;
        }
        else
        {
            currentStep = _step;
        }

        while (_isMove)
        {
            yield return null;

            _rigidbody.velocity = new Vector2(currentStep * _speed, _rigidbody.velocity.y);
        }
    }
}
