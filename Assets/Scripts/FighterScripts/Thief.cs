using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Fighter
{
    [SerializeField] private ThiefAnimationShower _animationShower;

    private void OnEnable()
    {
        CharacterMover.StartMoved += _animationShower.PlayMove;
        CharacterMover.EndMoved += _animationShower.StopPlayMove;
    }

    private void OnDisable()
    {
        CharacterMover.StartMoved += _animationShower.PlayMove;
        CharacterMover.EndMoved += _animationShower.StopPlayMove;
    }
}
