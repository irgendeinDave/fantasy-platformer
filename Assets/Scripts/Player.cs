using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float MoveForce = 10f;
    [SerializeField] private float MaxMoveSpeed = 15f;
    
    [SerializeField] private float JumpForce = 50f;
    private Rigidbody2D rb;

    [SerializeField] private GameObject feet;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.angularVelocity = 0;
        
        if ((rb.velocity.x < MaxMoveSpeed && Input.GetAxis("Horizontal") > 0) || 
            (rb.velocity.x > -MaxMoveSpeed && Input.GetAxis("Horizontal") < 0))
        {
            rb.AddForce(Vector2.right * (MoveForce * Input.GetAxis("Horizontal")));
            // show animation
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && feet.GetComponent<FeetCollsion>().IsTouchingGround)
        {
            rb.AddForce(Vector2.up * JumpForce);
            // show animation
        }
    }
}
