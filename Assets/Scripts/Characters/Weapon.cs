using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;

    public event Action<IDamageable, IDefenceable, bool> HittedOther;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & _targetLayer.value) != 0)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable target))
            {
                if (collision.gameObject.TryGetComponent(out IDefenceable defenceable))
                {
                    HittedOther?.Invoke(target, defenceable, false);
                }
            }
        }
    }
}
