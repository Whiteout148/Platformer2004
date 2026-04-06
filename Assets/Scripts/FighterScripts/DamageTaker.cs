using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;

    public void TakeDamage(float damage)
    {
        _health.Reduce(damage);
    }
}
