using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : Character
{
    [SerializeField] private float sightDistance = 10;
    [SerializeField] private float breakingForce = 100;
    [SerializeField] private Sprite 
    protected override void Attack()
    {
        
    }

    protected override void Move()
    {
        if (player == null) return;
        
        int direction = 0; // -1 to move left; 1 to move right

        // check if player is in Sight using Raycasts and move towards him
        Vector2 origin = new(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.left, sightDistance);
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
            direction = -1;
        else 
        {
            hit = Physics2D.Raycast(origin, Vector2.right, sightDistance);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
                direction = 1;
            else // slow down enemy if player is not next to it
                _rb.velocity -= _rb.velocity * (breakingForce * Time.deltaTime);
        }
        
        // slow down the enemy if it gets to close to the player
        float distanceToPlayer = Mathf.Abs(Vector2.Distance(transform.position, player.transform.position));
        if (distanceToPlayer < AttackRange)
        {
            _rb.velocity -= _rb.velocity * (breakingForce * Time.deltaTime);
            return;
        }
        
        // accelerate enemy if the maximum velocity has not been reached yet
        if ((_rb.velocity.x < MaxMoveSpeed && direction > 0) || 
            (_rb.velocity.x > -MaxMoveSpeed && direction < 0))
        {
            _rb.AddForce(Vector2.right * (MoveForce * direction));
            // TODO: show animation
        }
    }
}
