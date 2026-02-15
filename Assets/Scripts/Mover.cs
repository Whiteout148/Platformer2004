using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Rendering;

public class Mover : MonoBehaviour
{
    private const float leftScaleX = -1f;
    private const float rightScaleX = 1f;

    [SerializeField] private float _step = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private InputReader _reader;

    private Vector3 _scaleOnGoRight;
    private Vector3 _scaleOnGoLeft;
    private Coroutine _moveCoroutine;
    private bool _isMove = false;

    public event Action StartMoved;
    public event Action EndMoved;

    private void Awake()
    {
        _scaleOnGoLeft = new Vector3(leftScaleX, transform.localScale.y, transform.localScale.z);
        _scaleOnGoRight = new Vector3(rightScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void OnEnable()
    {
        _reader.PressedMoveKey += Move;
        _reader.StopPressedMoveKey += StopMove;
    }

    private void OnDisable()
    {
        _reader.PressedMoveKey -= Move;
        _reader.StopPressedMoveKey -= StopMove;
    }

    public void Move(float step)
    {
        StartMoved?.Invoke();
        _isMove = true;

        if (step < 0)
        {
            step -= _step;
            MoveRight(step);
        }
        else if (step > 0)
        {
            step += _step;
            MoveLeft(step);
        }
    }

    private void MoveRight(float step)
    {
        if (_moveCoroutine == null)
        {
            transform.localScale = _scaleOnGoRight;
            _moveCoroutine = StartCoroutine(DirectionMove(step));
        }
    }

    private void MoveLeft(float step)
    {
        if (_moveCoroutine == null)
        {
            transform.localScale = _scaleOnGoLeft;
            _moveCoroutine = StartCoroutine(DirectionMove(step));
        }
    }

    private void StopMove()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }

        _isMove = false;

        EndMoved?.Invoke();
    }
    
    private IEnumerator DirectionMove(float step)
    {
        while (_isMove)
        {
            transform.position += new Vector3(step, 0f, 0f) * _speed * Time.deltaTime;

            yield return null;
        }
    }
}
