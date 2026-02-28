using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AnimationShower : MonoBehaviour
{
    protected int IsWalking = Animator.StringToHash("IsWalk");

    [SerializeField] protected Animator Animator;
    
    public void PlayMove()
    {
        Animator.SetBool(IsWalking, true);
    }

    public void StopPlayMove()
    {
        Animator.SetBool(IsWalking, false);
    }
}
