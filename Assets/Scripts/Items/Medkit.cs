using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : Item
{
    [SerializeField] private float _count;

    public float Count => _count;
}
