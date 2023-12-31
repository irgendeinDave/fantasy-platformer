using UnityEngine;

/// <summary>
/// abstract class that contains features that the player and all enemies have
/// </summary>
public abstract class Character : MonoBehaviour
{
    // Movement
    protected int JumpForce { get; set; } = 450;
    protected int MoveForce { get; set; } = 25;
    protected float MaxMoveSpeed { get; set; } = 1.7f;
    
    // Combat
    private int Health { get;  set; } = 100;
    protected int BaseAttack { get; set; } = 15;
    protected float AttackRange { get; set; } = 1.2f;
    protected float AttackDamage; // from Weapon
    protected float CritModifier;
    protected float CritChance; // from Character
    [SerializeField] protected Weapon weapon;

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
        
        transform.rotation = Quaternion.identity;
        
        if (Health <= 0)
            Die();
        
        if (transform.position.y < -25)
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
