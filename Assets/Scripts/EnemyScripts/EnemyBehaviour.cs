using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Patroller _patroller;

    private BehaviourState _state;

    private bool _isPatroling = false;

    private void Start()
    {
        _state = BehaviourState.Normal; 
    }

    private void OnApplicationQuit()
    {
        _patroller.StopPatroling();
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

            _patroller.StartPatroling();
        }
    }
}

