using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : Fighter
{
    [SerializeField] private PriestAnimationShower _animationShower;

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
}
