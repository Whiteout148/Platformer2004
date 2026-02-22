using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour, IDamageable
{
    [SerializeField] protected float Force;
    [SerializeField] protected float Health;
    [SerializeField] protected Mover CharacterMover;

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public virtual void Attack(IDamageable target)
    {
        target.TakeDamage(Force);
    }
}
