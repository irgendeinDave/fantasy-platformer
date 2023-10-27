using System;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private float MoveForce = 10f;
    [SerializeField] private float MaxMoveSpeed = 15f;
    
    [SerializeField] private float JumpForce = 50f;
    private Rigidbody2D rb;

    protected override void Move()
    {
        _rb.angularVelocity = 0;
        
        if ((_rb.velocity.x < MaxMoveSpeed && Input.GetAxis("Horizontal") > 0) || 
            (_rb.velocity.x > -MaxMoveSpeed && Input.GetAxis("Horizontal") < 0))
        {
            _rb.AddForce(Vector2.right * (MoveForce * Input.GetAxis("Horizontal")));
            // show animation
        }
    }

    protected override void Attack()
    {
        
    }

    protected override void Jump()
    {
        _rb.AddForce(Vector2.up * JumpForce);
        // show animation
    }
    
}
