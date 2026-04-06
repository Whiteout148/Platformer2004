using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defencer : MonoBehaviour, IDefenceable
{
    [SerializeField] private float _defencingTime;

    private Coroutine _defencingCoroutine;
    private WaitForSeconds _delay;

    public bool IsDefencing { get; private set; }
    private IStunneable _stunneable;
    private IDefenceAnimator _animator;

    private void Awake()
    {
        _animator = GetComponent<AnimationShower>();
        _stunneable = GetComponent<Stunner>();
        _delay = new WaitForSeconds(_defencingTime);
    }

    public void StartDefence()
    {
        if (_defencingCoroutine == null && !_stunneable.IsStunn)
        {
            _defencingCoroutine = StartCoroutine(Defence());
        }
    }

    private IEnumerator Defence()
    {
        IsDefencing = true;
        _animator.PlayDefence();

        yield return _delay;

        IsDefencing = false;
        _animator.StopPlayDefence();

        _defencingCoroutine = null;
    }
}
