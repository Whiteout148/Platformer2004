using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graviter : MonoBehaviour
{
    [SerializeField] private Grounder _grounder;
    [SerializeField] private float _force = 5f;

    private float _velocity = 1f;

    private void Update()
    {
        FallDown();
    }

    private void FallDown()
    {
        _velocity += _force * Time.deltaTime;

        if (!_grounder.IsGround)
        {
            transform.position += Vector3.down * _velocity * Time.deltaTime;
        }
        else
        {
            _velocity = 0;
        }
    }
}
