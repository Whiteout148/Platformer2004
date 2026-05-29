using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : MonoBehaviour
{
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _absorbTime;
    [SerializeField] private EnemyDetector _detector;
    [SerializeField] private VampireDamager _damager;

    private Coroutine _absorbCoroutine;
    private bool _canStartAbsorb = true;

    public event Action<float> AbsorbingStart;
    public event Action<float> ReloadingStart;

    private void Awake()
    {
        _detector.enabled = false;
    }

    private void OnEnable()
    {
        _detector.EnemyDetected += _damager.OnEnemyHitted;
    }

    private void OnDisable()
    {
        _detector.EnemyDetected -= _damager.OnEnemyHitted;
    }

    public void StartAbsorbing()
    {
        if (_canStartAbsorb)
        {
            _absorbCoroutine = StartCoroutine(AbsorbHealth());
        }
    }

    private IEnumerator AbsorbHealth()
    {
        _canStartAbsorb = false;
        _detector.enabled = true;

        AbsorbingStart?.Invoke(_absorbTime);
        yield return new WaitForSeconds(_absorbTime);

        _detector.enabled = false;

        ReloadingStart?.Invoke(_reloadTime);
        yield return new WaitForSeconds(_reloadTime);

        _canStartAbsorb = true;
        _absorbCoroutine = null;
    }
}
