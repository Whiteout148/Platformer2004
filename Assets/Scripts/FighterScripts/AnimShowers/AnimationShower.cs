using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AnimationShower : MonoBehaviour
{
    private const int BaseLayer = 0;
    private const int AttackLayer = 1;
    private const string WalkingBoolName = "IsWalk";
    private const string AttackingTriggerName = "Attacking";
    private const string AttackStateName = "attack";

    public readonly int IsWalking = Animator.StringToHash(WalkingBoolName);
    public readonly int Attacking = Animator.StringToHash(AttackingTriggerName);
    public readonly int AttackingFull = Animator.StringToHash("DamageAttack." + AttackingTriggerName);
    public readonly int Attack2 = Animator.StringToHash(AttackStateName);

    [SerializeField] protected Animator Animator;
    [SerializeField] private float MinNormalizedTime = 0.5f;

    public bool IsAnimateAttack()
    {
        AnimatorStateInfo state = Animator.GetCurrentAnimatorStateInfo(AttackLayer);

        if (state.shortNameHash == Attack2 && state.normalizedTime > MinNormalizedTime)
        {
            return true;
        }

        return false;
    }

    public void PlayAttack()
    {
        Animator.SetTrigger(Attacking);
    }

    public void PlayMove()
    {
        Animator.SetBool(IsWalking, true);
    }

    public void StopPlayMove()
    {
        Animator.SetBool(IsWalking, false);
    }
}
