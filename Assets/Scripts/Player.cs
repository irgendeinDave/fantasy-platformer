using System;
using UnityEngine;

public class Player : Character
{
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
        if (Input.GetKeyDown(KeyCode.Space) && feet.GetComponent<FeetCollsion>().IsTouchingGround)
        {
            _rb.AddForce(Vector2.up * JumpForce);
            // show animation
        }
    }

    protected void OnTriggerEnter(Collider other)
    {   
        transform.rotation = Quaternion.identity;
    }
}
