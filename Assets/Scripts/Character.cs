using UnityEngine;

/// <summary>
/// abstract class that contains features that the player and all enemies have
/// </summary>
public abstract class Character : MonoBehaviour
{
    private int Health { get;  set; } = 100;
    protected int JumpForce { get; set; } = 450;
    protected int MoveForce { get; set; } = 25;
    protected int MaxMoveSpeed { get; set; } = 10;

    protected Rigidbody2D _rb;
    [SerializeField] protected GameObject feet;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Move();
        Jump();
        
        if (Health <= 0)
            Die();
    }

    protected abstract void Attack();
    protected abstract void Jump();
    protected abstract void Move();

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
