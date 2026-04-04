using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunner : MonoBehaviour
{
    [SerializeField] private float _stunnTime;

    private WaitForSeconds _delay;
    private Coroutine _Coroutine;

    public event Action StartedStunn;
    public event Action EndStunn;

    private void Awake()
    {
        _delay = new WaitForSeconds(_stunnTime);
    }

    public void StartStunn()
    {
        if (_Coroutine == null)
        {
            _Coroutine = StartCoroutine(Stunn());
        }
    }

    private IEnumerator Stunn()
    { 
        StartedStunn?.Invoke();

        yield return _delay;

        EndStunn?.Invoke();

        _Coroutine = null;
    }
}
