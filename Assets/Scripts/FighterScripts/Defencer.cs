using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defencer : MonoBehaviour
{
    [SerializeField] private float _defencingTime;

    public event Action StartingDefence;
    public event Action EndDefence;

    private Coroutine _defencingCoroutine;
    private WaitForSeconds _delay;

    private void Awake()
    {
        _delay = new WaitForSeconds(_defencingTime);
    }

    public void StartDefence()
    {
        if (_defencingCoroutine == null)
        {
            _defencingCoroutine = StartCoroutine(Defence());
        }
    }

    private IEnumerator Defence()
    {
        StartingDefence?.Invoke();

        yield return _delay;

        EndDefence?.Invoke();

        _defencingCoroutine = null;
    }
}
