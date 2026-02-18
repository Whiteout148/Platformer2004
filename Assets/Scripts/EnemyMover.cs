using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMover : Mover
{
    private Coroutine _moveCoroutine;

    public void StartMoveToTarget(PointEnemy target)
    {
        if (_moveCoroutine == null)
        {
            base.Move(Step);

            _moveCoroutine = StartCoroutine(MoveToTarget(target));
        }
    }

    public void StopMoveToTarget()
    {
        if (_moveCoroutine != null)
        {
            base.StopMove();
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }
    }

    public Vector3 GetRandomScale()
    {
        Vector3[] scales =
        {
            ScaleOnGoLeft, ScaleOnGoRight,
        };

        Vector3 scale = scales[Random.Range(0, scales.Length)];

        return scale;
    }

    private IEnumerator MoveToTarget(PointEnemy target)
    {
        float step = Step * Speed;

        if (target.transform.position.x < transform.position.x)
        {
            transform.localScale = ScaleOnGoRight;
        }
        else
        {
            transform.localScale = ScaleOnGoLeft;
        }

        while (IsMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step * Time.deltaTime);

            yield return null;
        }
    }
}
