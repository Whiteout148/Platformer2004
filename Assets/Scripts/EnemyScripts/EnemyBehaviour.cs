using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Patrol _patrol;

    private BehaviourState _state;

    private bool _isPatroling = false;

    private void Start()
    {
        _state = BehaviourState.Normal; 
    }

    private void OnApplicationQuit()
    {
        _patrol.StopPatroling();
    }

    private void Update()
    {
        ManageBehaviour();
    }

    private void ManageBehaviour()
    {
        if (_state == BehaviourState.Normal && _isPatroling == false)
        {
            _isPatroling = true;

            _patrol.StartPatroling();
        }
    }
}

