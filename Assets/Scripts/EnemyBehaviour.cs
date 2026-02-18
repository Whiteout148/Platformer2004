using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBehaviour : MonoBehaviour
{
    private const float MinRandomTime = 3f;
    private const float MaxRandomTime = 10f;

    [SerializeField] private List<PointEnemy> _enemyPoints;
    [SerializeField] private EnemyMover _mover;
    private BehaviourState _state;

    private Coroutine _behaviourCoroutine;
    private Coroutine _lookCoroutine;

    private bool _isRunning = true;
    private bool _isLooking = false;

    private void Start()
    {
        _state = BehaviourState.Normal;
        StartBehaviouring();
    }

    private void OnApplicationQuit()
    {
        if (_behaviourCoroutine != null)
        {
            _isRunning = false;
            StopCoroutine(_behaviourCoroutine);
        }
    }

    private void StartBehaviouring()
    {
        if (_behaviourCoroutine == null)
        {
            _isRunning = true;
            _behaviourCoroutine = StartCoroutine(SetBehaviour());
        }
    }

    private IEnumerator SetBehaviour()
    {
        while (_isRunning)
        {
            WaitForSeconds delay = new WaitForSeconds(Random.Range(MinRandomTime, MaxRandomTime));
            PointEnemy target = _enemyPoints[Random.Range(0, _enemyPoints.Count)];

            if (_state == BehaviourState.Normal)
            {
                _mover.StartMoveToTarget(target);

                if (transform.position.x == target.transform.position.x)
                {
                    _mover.StopMoveToTarget();

                    if (_lookCoroutine == null)
                    {
                        _isLooking = true;
                        _lookCoroutine = StartCoroutine(LookAroundBody());

                        yield return delay;

                        _isLooking = false;
                        StopCoroutine(_lookCoroutine);
                        _lookCoroutine = null;
                    }
                }
            }

            yield return null;
        }
    }

    private IEnumerator LookAroundBody()
    {
        while (_isLooking)
        {
            transform.localScale = _mover.GetRandomScale();

            yield return new WaitForSeconds(Random.Range(MinRandomTime, MaxRandomTime));
        }
    }
}

