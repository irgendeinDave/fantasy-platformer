using UnityEngine;

/// <summary>
/// abstract class that contains features that the player and all enemies have
/// </summary>
public abstract class Character : MonoBehaviour
{
    protected int JumpForce { get; set; } = 450;
    protected int MoveForce { get; set; } = 25;
    protected float MaxMoveSpeed { get; set; } = 1.7f;
    
    private int Health { get;  set; } = 100;
    protected int BaseAttack { get; set; } = 15;
    protected float AttackRange { get; set; } = 1.2f;

    protected Rigidbody2D _rb;
    [SerializeField] protected GameObject feet;
    protected GameObject player;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        Move();
        Jump();
        
        if (Health <= 0)
            Die();
    }

    protected abstract void Attack();
    protected virtual void Jump() { }
    protected abstract void Move();

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
