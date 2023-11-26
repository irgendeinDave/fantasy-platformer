using System;
using UnityEngine;

public class Player : Character
{
    protected override void Move()
    {
        // accelerate player if the maximum velocity has not yet been reached
        if ((_rb.velocity.x < MaxMoveSpeed && Input.GetAxis("Horizontal") > 0) || 
            (_rb.velocity.x > -MaxMoveSpeed && Input.GetAxis("Horizontal") < 0))
        {
            _rb.AddForce(Vector2.right * (MoveForce * Input.GetAxis("Horizontal")));
            // TODO: show animation
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
