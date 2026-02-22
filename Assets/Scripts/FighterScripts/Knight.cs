using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Fighter
{
    [SerializeField] private KnightAnimationShower _animationShower;
    [SerializeField] private float _armor;

    private void OnEnable()
    {
        CharacterMover.StartMoved += _animationShower.OnStartMove;
        CharacterMover.EndMoved += _animationShower.OnEndMove;
    }

    private void OnDisable()
    {
        CharacterMover.StartMoved += _animationShower.OnStartMove;
        CharacterMover.EndMoved += _animationShower.OnEndMove;
    }

    public override void TakeDamage(float damage)
    {
        Health -= damage - _armor;

        if (damage - _armor < 0)
        {
            damage = 0;
        }
    }
}
