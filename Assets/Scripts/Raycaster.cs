using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private const float GroundCheckDistance = 0.1f;

    [SerializeField] private LayerMask _groundMask;
    public bool IsGround { get; private set; }

    private void Update()
    {
        IsGround = IsGrounded();
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector3.down, GroundCheckDistance, _groundMask);
    }
}
