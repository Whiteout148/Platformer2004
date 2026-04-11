using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationShower : MonoBehaviour, IAttackAnimater, IDefenceAnimator
{
    private const int BaseLayer = 0;
    private const int AttackLayer = 1;
    private const string WalkingBoolName = "IsWalk";
    private const string DieBoolName = "IsDie";
    private const string AttackingTriggerName = "Attacking";
    private const string AttackStateName = "attack";
    private const string DefenceBoolName = "IsCasting";

    public readonly int IsCasting = Animator.StringToHash(DefenceBoolName);
    public readonly int IsDie = Animator.StringToHash(DieBoolName);
    public readonly int IsWalking = Animator.StringToHash(WalkingBoolName);
    public readonly int Attacking = Animator.StringToHash(AttackingTriggerName);
    public readonly int AttackingFull = Animator.StringToHash("DamageAttack." + AttackingTriggerName);
    public readonly int Attack2 = Animator.StringToHash(AttackStateName);

    [SerializeField] private Animator _animator;
    [SerializeField] private float MinNormalizedTime = 0.5f;

    private bool _isCasting = false;

    public bool IsAnimateAttack()
    {
        AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(AttackLayer);

        if (state.shortNameHash == Attack2 && state.normalizedTime > MinNormalizedTime)
        {
            return true;
        }

        return false;
    }

    public void PlayDie()
    {
        _animator.SetBool(IsCasting, false);
        _animator.SetBool(IsWalking, false);
        _animator.SetBool(IsDie, true);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(Attacking);
    }

    public void PlayMove()
    {
        _animator.SetBool(IsWalking, true);
    }

    public void StopPlayMove()
    {
        _animator.SetBool(IsWalking, false);
    }

    public void PlayDefence()
    {
        _animator.SetBool(IsCasting, true);
        _isCasting = true;
    }

    public void StopPlayDefence()
    {
        _animator.SetBool(IsCasting, false);
        _isCasting = false;
    }
}
