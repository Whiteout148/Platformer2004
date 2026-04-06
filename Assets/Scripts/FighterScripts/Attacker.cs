using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Stunner _stunner;

    private IDefenceable _defencer;
    private IAttackAnimater _attackAnimator;
    private bool _isAttack = false;

    public event Action Attacked;

    private void Awake()
    {
        _defencer = GetComponent<Defencer>();
        _attackAnimator = GetComponent<AnimationShower>();
    }

    private void OnEnable()
    {
        _weapon.HittedOther += OnHitOther;
    }

    private void OnDisable()
    {
        _weapon.HittedOther -= OnHitOther;
    }

    public void Attack()
    {
        if (!_defencer.IsDefencing)
        {
            if (!_stunner.IsStunn)
            {
                _attackAnimator.PlayAttack();
                _isAttack = true;
            }
        }
    }

    private void OnHitOther(IDamageable damageableTarget, IDefenceable defenceableTarget)
    {
        if (_attackAnimator.IsAnimateAttack())
        {
            if (_isAttack)
            {
                _isAttack = false;

                if (defenceableTarget.IsDefencing)
                {
                    _stunner.StartStunn();
                }
                else
                {
                    damageableTarget.TakeDamage(_force);
                    Attacked?.Invoke();
                }
            }
        }
    }
}
