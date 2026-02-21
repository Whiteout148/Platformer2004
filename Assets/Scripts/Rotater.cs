using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    private const float LeftRotation = 0f;
    private const float RightRotation = 180f;

    private Vector3 _rotationLeft;
    private Vector3 _rotationRight;

    private void Awake()
    {
        _rotationLeft = new Vector3(transform.rotation.x, LeftRotation, transform.rotation.z);
        _rotationRight = new Vector3(transform.rotation.x, RightRotation, transform.rotation.z);
    }

    public void SetDirection(float direction)
    {
        if (direction < 0)
        {
            transform.eulerAngles = _rotationLeft;
        }
        else if (direction > 0)
        {
            transform.eulerAngles = _rotationRight;
        }
    }
}
