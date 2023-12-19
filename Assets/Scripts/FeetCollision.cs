using System;
using UnityEngine;

public class FeetCollision : MonoBehaviour
{
    public bool IsTouchingGround { get; private set; }
    private BoxCollider2D _feetCollider;

    private void Awake()
    {
        _feetCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entering trigger");
        if (!other.gameObject.CompareTag("Player"))
            IsTouchingGround = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            IsTouchingGround = false;
    }
}
 