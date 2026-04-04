using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Persecutter : MonoBehaviour
{
    [SerializeField] private AroundChecker _checker;
    [SerializeField] private Mover _mover;
    [SerializeField] private Rotater _rotater;

    private Coroutine _persecutionCoroutine;
    private bool _isRunning = false;

    public event Action ReadyToAttack;
    public event Action StartMoveing;
    public event Action StopMoveing;

    public void StartPersecuting(Player target)
    {
        if (_persecutionCoroutine == null)
        {
            _isRunning = true;
            _persecutionCoroutine = StartCoroutine(Chase(target));
        }
    }

    public void StopPersecuting()
    {
        if (_persecutionCoroutine != null)
        {
            _isRunning = false;
            StopCoroutine(_persecutionCoroutine);
            _persecutionCoroutine = null;
            _mover.StopMove();
        }
    }

    private IEnumerator Chase(Player target)
    {
        float pointDirection;

        while (_isRunning)
        {
            if (target.transform.position.x < transform.position.x)
            {
                pointDirection = -1f;
            }
            else
            {
                pointDirection = 1f;
            }

            if (_checker.IsNear)
            {
                ReadyToAttack?.Invoke();
                _mover.StopMove();
                StopMoveing?.Invoke();
            }
            else
            {
                _mover.StopMove();
                _mover.Move(pointDirection);
                StartMoveing?.Invoke();
            }

            _rotater.SetDirection(pointDirection);

            yield return null;
        }

        _mover.StopMove();
    }
}
