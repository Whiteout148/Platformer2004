using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _count;

    public void Reduce(float toReduce)
    {
        _count -= toReduce;
    }

    public void Add(float toAdd)
    {
        _count += toAdd;
    }
}
