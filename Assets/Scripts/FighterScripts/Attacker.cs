using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private AnimationShower _shower;
    [SerializeField] private Stunner _stunner;

    private bool _isAttack = false;
    private bool _isStunned = false;

    public event Action Attacked;

    private void OnEnable()
    {
        _shower.StartedAttack += OnAttackStarted;
        _weapon.HittedOther += OnHitOther;
    }

    private void OnDisable()
    {
        _shower.StartedAttack -= OnAttackStarted;
        _weapon.HittedOther -= OnHitOther;
    }

    private void OnAttackStarted(bool isAttack)
    {
        _isAttack = isAttack;
    }

    private void OnHitOther(IDamageable target)
    {
        if (_shower.IsAnimateAttack())
        {
            if (_isAttack)
            {
                if (target.IsDefencing)
                {
                    _stunner.StartStunn();
                    _isAttack = false;
                }
                else
                {
                    target.TakeDamage(_force);
                    Attacked?.Invoke();
                    _isAttack = false;
                }
            }
        }
    }
}
