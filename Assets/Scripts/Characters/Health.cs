using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _count;

    public event Action Dead;
    
    public void AddCount(float count)
    {
        _count += count;

        if (_count <= 0)
        {
            Dead?.Invoke();
        }
        else if (_count > _maxHealth)
        {
            _count = _maxHealth;
        }
    }
}
