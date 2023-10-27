using UnityEngine;

/// <summary>
/// abstract class that contains features that the player and all enemies have
/// </summary>
public abstract class Character : MonoBehaviour
{
    public int Health { get; protected set; }
    public int JumpForce { get; protected set; }
    public int MoveForce { get; protected set; }
    public int MaxMoveSpeed { get; protected set; }

    protected Rigidbody2D _rb;
    [SerializeField] private GameObject feet;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && feet.GetComponent<FeetCollsion>().IsTouchingGround)
        {
            Jump();
        }
    }

    protected abstract void Attack();
    protected abstract void Jump();
    protected abstract void Move();

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
