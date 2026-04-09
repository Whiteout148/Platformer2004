using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _count;

    public event Action Dead;

    public void Reduce(float toReduce)
    {
        _count -= toReduce;

        if (_count <= 0)
        {
            Dead?.Invoke();
        }
    }

    public void Add(float toAdd)
    {
        _count += toAdd;
    }
}
