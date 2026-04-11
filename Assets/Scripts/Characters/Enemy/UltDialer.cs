using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltDialer : MonoBehaviour
{
    [SerializeField] private float _minUlt;
    [SerializeField] private float _maxUlt;

    private float _waitTime = 1f;
    private float _currentUlt;
    private float _currentMaxUlt;

    public event Action Reached;

    private Coroutine _coroutine;

    private void Start()
    {
        _currentMaxUlt = UnityEngine.Random.Range(_minUlt, _maxUlt + 1);
        _currentUlt = 0;
    }

    public void SetUlt()
    {
        if (_currentUlt == _currentMaxUlt - 1)
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(ShowSign());
            }
        }

        if (_currentUlt >= _currentMaxUlt)
        {
            Reached?.Invoke();

            _currentMaxUlt = UnityEngine.Random.Range(_minUlt, _maxUlt + 1);
        }
        else
        {
            _currentUlt++;
        }
    }

    private IEnumerator ShowSign()
    {
        yield return new WaitForSeconds(_waitTime);

        _coroutine = null;
    }
}
