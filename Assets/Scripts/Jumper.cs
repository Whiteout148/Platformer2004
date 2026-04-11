using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private GroundDetector _grounder;
    [SerializeField] private Rigidbody2D _rigidbody;

    public void Jump()
    {
        if (_grounder.IsGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
}
