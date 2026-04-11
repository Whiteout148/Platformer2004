using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persecutter : MonoBehaviour
{
    [SerializeField] private AroundChecker _checker;
    [SerializeField] private TowardsMover _mover;

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
            _mover.StopMoveToTarget();
        }
    }

    private IEnumerator Chase(Player target)
    {
        float pointDirection;

        while (_isRunning)
        {
            if (_checker.IsNear)
            {
                ReadyToAttack?.Invoke();
                _mover.StopMoveToTarget();
                StopMoveing?.Invoke();
            }
            else
            {
                _mover.StopMoveToTarget();
                _mover.MoveToTarget(target.transform);
                StartMoveing?.Invoke();
            }

            yield return null;
        }

        _mover.StopMoveToTarget();
    }
}
