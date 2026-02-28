using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Patroller : MonoBehaviour
{
    private const float MinRandomTime = 1f;
    private const float MaxRandomTime = 4f;
    private const int MinBehaviourCount = 2;
    private const int MaxBehaviourCount = 4;

    [SerializeField] private List<PointEnemy> _enemyPoints;
    [SerializeField] private Mover _mover;
    [SerializeField] private Rotater _rotater;

    private PointEnemy _currentPoint;
    private Coroutine _patrolingCoroutine;

    private bool _isRunning = true;

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
        }
    }

    private IEnumerator Patroling()
    {
        while (_isRunning)
        {
            GoToRandomPoint();

            yield return new WaitUntil(() => IsOnPoint());

            int behaviourCount = Random.Range(MinBehaviourCount, MaxBehaviourCount);

            for (int i = 0; i < behaviourCount; i++)
            {
                _rotater.Flip();

                yield return new WaitForSeconds(Random.Range(MinRandomTime, MaxRandomTime));
            }
        }
    }

    private void GoToRandomPoint()
    {
        _currentPoint = GetPoint();

        float pointDirection;

        if (_currentPoint.transform.position.x < transform.position.x)
        {
            pointDirection = -1f;
        }
        else
        {
            pointDirection = 1f;
        }

        _rotater.SetDirection(pointDirection);
        _mover.Move(pointDirection);
    }

    private bool IsOnPoint()
    {
        if (Mathf.Abs(transform.position.x - _currentPoint.transform.position.x) < 0.1f)
        {
            _mover.StopMove();

            return true;
        }

        if (Mathf.Approximately(transform.position.x, _currentPoint.transform.position.x))
        {
            _mover.StopMove();

            return true;
        }

        return false;
    }

    private PointEnemy GetPoint()
    {
        return _enemyPoints[Random.Range(0, _enemyPoints.Count)];
    }
}
