using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    private const float RadiusFactor = 0.5f;

    [SerializeField] private RectTransform _overlapTransform;

    public event Action<IDamageable> EnemyDetected;

    private void Update()
    {
        if (enabled)
        {
            float radius = _overlapTransform.rect.width * RadiusFactor * _overlapTransform.lossyScale.x;

            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].TryGetComponent(out Enemy enemy))
                {
                    if (hits[i].TryGetComponent(out IDamageable hitDamageable))
                    {
                        EnemyDetected?.Invoke(hitDamageable);
                    }
                }
            }
        }
    }
}
