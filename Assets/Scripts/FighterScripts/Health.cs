using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _count;

    public event Action Dead;

    private void Update()
    {
        if (_count <= 0)
        {
            Dead?.Invoke();
        }
    }

    public void Reduce(float toReduce)
    {
        _count -= toReduce;
    }

    public void Add(float toAdd)
    {
        _count += toAdd;
    }
}
