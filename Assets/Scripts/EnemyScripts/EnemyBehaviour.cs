using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Patroller _patroller;
    [SerializeField] private Persecutter _persecutter;
    [SerializeField] private PlaceDetector _detector;
    [SerializeField] private Fighter _fighter;

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
        _persecutter.ReadyToAttack += _fighter.Attack;
    }

    private void OnDisable()
    {
        _detector.ComeOnPlace -= OnDetectPlayer;
        _detector.GetOutOnPlace -= OnPlayerLeave;
        _persecutter.ReadyToAttack -= _fighter.Attack;
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

