using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private InputReader _reader;
    [SerializeField] private AnimationShower _shower;
    [SerializeField] private Health _health;
    [SerializeField] private ItemCollecter _collecter;
    [SerializeField] private Defencer _defencer;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Stunner _stunner;

    private IDirectionSetter _directionSetter;

    private void Awake()
    {
        _directionSetter = GetComponent<Rotater>();
    }

    private void OnEnable()
    {
        _collecter.GettedMedkit += _health.Add;
        _reader.PressedMoveKey += _mover.Move;
        _reader.PressedMoveKey += _directionSetter.SetDirection;
        _reader.StopPressedMoveKey += _mover.StopMove;
        _reader.PressedJumpButton += _jumper.Jump;
        _reader.PressedAttackButton += _attacker.Attack;
        _mover.StartMoved += _shower.PlayMove;
        _mover.EndMoved += _shower.StopPlayMove;
        _reader.PressedDefenceButton += _defencer.StartDefence;

        _health.Dead += OnDie;
        _health.Dead += _shower.PlayDie;
    }

    private void OnDisable()
    {
        _health.Dead -= OnDie;
        _health.Dead -= _shower.PlayDie;
    }

    private void OnDie()
    {
        _collecter.GettedMedkit -= _health.Add;
        _reader.PressedMoveKey -= _mover.Move;
        _reader.PressedMoveKey -= _directionSetter.SetDirection;
        _reader.StopPressedMoveKey -= _mover.StopMove;
        _reader.PressedJumpButton -= _jumper.Jump;
        _reader.PressedAttackButton -= _shower.PlayAttack;
        _reader.PressedDefenceButton -= _defencer.StartDefence;

        _mover.StartMoved -= _shower.PlayMove;
        _mover.EndMoved -= _shower.StopPlayMove;
    }
}
