using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patroller _patroller;
    [SerializeField] private Persecutter _persecutter;
    [SerializeField] private PlayerDetector _detector;
    [SerializeField] private AnimationShower _shower;
    [SerializeField] private Health _health;
    [SerializeField] private Defencer _defencer;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Stunner _stunner;
    [SerializeField] private UltDialer _ulter;

    private BehaviourState _state;
    private Player _target;

    private void Start()
    {
        _state = BehaviourState.Normal;

        _patroller.StartPatroling();
    }

    private void OnEnable()
    {
        _detector.ComeOnPlace += OnDetectPlayer;
        _detector.GetOutOnPlace += OnPlayerLeave;
        _persecutter.ReadyToAttack += _attacker.Attack;
        _persecutter.StartMoveing += _shower.PlayMove;
        _persecutter.StopMoveing += _shower.StopPlayMove;
        _patroller.StartMoveing += _shower.PlayMove;
        _patroller.StopMoveing += _shower.StopPlayMove;
        _health.Dead += _patroller.StopPatroling;
        _health.Dead += _persecutter.StopPersecuting;
        _health.Dead += OnDie;
        _health.Dead += _shower.PlayDie;
        _attacker.Attacked += _ulter.SetUlt;
        _ulter.Reached += _defencer.StartDefence;
    }

    private void OnDisable()
    {
        _health.Dead -= OnDie;
        _health.Dead -= _shower.PlayDie;
    }
    
    private void OnDie()
    {
        _detector.ComeOnPlace -= OnDetectPlayer;
        _detector.GetOutOnPlace -= OnPlayerLeave;
        _persecutter.ReadyToAttack -= _attacker.Attack;
        _persecutter.StartMoveing -= _shower.PlayMove;
        _persecutter.StopMoveing -= _shower.StopPlayMove;
        _patroller.StartMoveing -= _shower.PlayMove;
        _patroller.StopMoveing -= _shower.StopPlayMove;
        _health.Dead -= _patroller.StopPatroling;
        _health.Dead -= _persecutter.StopPersecuting;
        _attacker.Attacked -= _ulter.SetUlt;
        _ulter.Reached -= _defencer.StartDefence;

        if (transform.TryGetComponent(out BoxCollider2D collider))
        {
            collider.enabled = false;
        }
        
        if (transform.TryGetComponent(out Rigidbody2D rigidbody))
        {
            Destroy(rigidbody);
        }
    }

    private void OnDetectPlayer(Player player)
    {
        _state = BehaviourState.Persecution;
        _target = player;

        _patroller.StopPatroling();
        _persecutter.StartPersecuting(_target);
    }

    private void OnPlayerLeave()
    {
        _persecutter.StopPersecuting();
        _target = null;

        _state = BehaviourState.Normal;
        _patroller.StartPatroling();
    }
}

