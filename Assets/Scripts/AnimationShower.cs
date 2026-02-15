using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationShower : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void OnStartMove()
    {
        _animator.SetBool("IsWalk", true);
    }

    public void OnEndMove()
    {
        _animator.SetBool("IsWalk", false);
    }
}
