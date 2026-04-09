using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rotater))]
public class Patroller : MonoBehaviour
{
    private const float MinRandomTime = 1f;
    private const float MaxRandomTime = 4f;
    private const int MinBehaviourCount = 2;
    private const int MaxBehaviourCount = 4;

    [SerializeField] private List<PointEnemy> _enemyPoints;
    [SerializeField] private TowardsMover _mover;

    private PointEnemy _currentPoint;
    private Coroutine _patrolingCoroutine;
    private IFlipper _flipper;

    private bool _isRunning = true;

    public event Action StartMoveing;
    public event Action StopMoveing;

    private void Awake()
    {
        _flipper = GetComponent<Rotater>();
    }

    public void StartPatroling()
    {
        if (_patrolingCoroutine == null)
        {
            _isRunning = true;
            _patrolingCoroutine = StartCoroutine(Patroling());
        }
    }

    public void StopPatroling()
    {
        if (_patrolingCoroutine != null)
        {
            _isRunning = false;
            StopCoroutine(_patrolingCoroutine);
            _mover.StopMoveToTarget();
            _patrolingCoroutine = null;
            _currentPoint = null;
        }
    }

    private IEnumerator Patroling()
    {
        while (_isRunning)
        {
            _currentPoint = GetPoint();
            _mover.MoveToTarget(_currentPoint.transform);
            StartMoveing?.Invoke();

            yield return new WaitUntil(() => _mover.IsOnPoint(_currentPoint.transform));

            StopMoveing?.Invoke();
            int flippingCount = UnityEngine.Random.Range(MinBehaviourCount, MaxBehaviourCount);

            for (int i = 0; i < flippingCount; i++)
            {
                _flipper.Flip();

                yield return new WaitForSeconds(UnityEngine.Random.Range(MinRandomTime, MaxRandomTime));
            }
        }
    }

    private PointEnemy GetPoint()
    {
        return _enemyPoints[UnityEngine.Random.Range(0, _enemyPoints.Count)];
    }
}
