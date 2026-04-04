using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Rendering;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _step = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Rigidbody2D _rigidbody;

    private bool _isMove = false;
    private Coroutine _moveCoroutine;
   
    public event Action StartMoved;
    public event Action EndMoved;

    private float _direction;

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

            yield return null;
        }
    }
}
