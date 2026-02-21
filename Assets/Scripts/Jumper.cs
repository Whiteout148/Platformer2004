using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Grounder _grounder;
    [SerializeField] private Rigidbody2D _rigidbody;

    public void Jump()
    {
        if (_grounder.IsGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
}
