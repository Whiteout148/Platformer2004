using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private Defencer _defencer;

    public bool IsDefencing { get; private set; }

    private void OnEnable()
    {
        _defencer.StartingDefence += OnStartDefencing;
        _defencer.EndDefence += OnEndDefencing;
    }

    private void OnDisable()
    {
        _defencer.StartingDefence -= OnStartDefencing;
        _defencer.EndDefence -= OnEndDefencing;
    }

    private void OnStartDefencing()
    {
        IsDefencing = true;
    }

    private void OnEndDefencing()
    {
        IsDefencing = false;
    }

    public void TakeDamage(float damage)
    {
        _health.Reduce(damage);
    }
}
