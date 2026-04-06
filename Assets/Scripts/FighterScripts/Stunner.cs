using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunner : MonoBehaviour, IStunneable
{
    [SerializeField] private float _stunnTime;

    private WaitForSeconds _delay;
    private Coroutine _Coroutine;

    public event Action StartedStunn;
    public event Action EndStunn;

    public bool IsStunn {  get; private set; }

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

        IsStunn = true;

        yield return _delay;

        EndStunn?.Invoke();

        IsStunn = false;

        _Coroutine = null;
    }
}
