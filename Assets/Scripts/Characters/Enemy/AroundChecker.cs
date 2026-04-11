using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundChecker : MonoBehaviour
{
    [SerializeField] private float _radius = 1f;
    [SerializeField] private LayerMask _targetLayer;

    public bool IsNear { get; private set; }

    private void Update()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, _radius, _targetLayer);
        IsNear = player != null;
    }
}
