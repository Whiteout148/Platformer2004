using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotater))]
public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private InputReader _reader;
    [SerializeField] private AnimationShower _shower;
    [SerializeField] private Health _health;
    [SerializeField] private ItemCollecter _collecter;
    [SerializeField] private ItemDistributor _distributor;
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
        _distributor.GettedMedkit += _health.AddCount;
        _reader.PressedMoveKey += _mover.Move;
        _reader.PressedMoveKey += _directionSetter.SetDirection;
        _reader.StopPressedMoveKey += _mover.StopMove;
        _reader.PressedJumpButton += _jumper.Jump;
        _reader.PressedAttackButton += _attacker.Attack;
        _mover.StartedMove += _shower.PlayMove;
        _mover.EndedMoved += _shower.StopPlayMove;
        _reader.PressedDefenceButton += _defencer.StartDefence;
        _health.Dead += _mover.StopMove;

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
        _distributor.GettedMedkit -= _health.AddCount;
        _reader.PressedMoveKey -= _mover.Move;
        _reader.PressedMoveKey -= _directionSetter.SetDirection;
        _reader.StopPressedMoveKey -= _mover.StopMove;
        _reader.PressedJumpButton -= _jumper.Jump;
        _reader.PressedAttackButton -= _attacker.Attack;
        _reader.PressedDefenceButton -= _defencer.StartDefence;
        _health.Dead -= _mover.StopMove;

        _mover.StartedMove -= _shower.PlayMove;
        _mover.EndedMoved -= _shower.StopPlayMove;
    }
}
