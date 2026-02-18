using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour, IDamageable
{
    [SerializeField] protected float Force;
    [SerializeField] protected float Health;
    [SerializeField] protected AnimationShower _animationShower;
    [SerializeField] protected Mover _mover;

    private void OnEnable()
    {
        _mover.StartMoved += _animationShower.OnStartMove;
        _mover.EndMoved += _animationShower.OnEndMove;
    }

    private void OnDisable()
    {
        _mover.StartMoved -= _animationShower.OnStartMove;
        _mover.EndMoved -= _animationShower.OnEndMove;
    }

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public virtual void Attack(IDamageable target)
    {
        target.TakeDamage(Force);
    }
}
