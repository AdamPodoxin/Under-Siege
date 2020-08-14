using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;

    public bool CanMove { get; set; } = true;

    private Vector2 movement;
    public Vector2 MovementDirection { get { return movement; } }

    private Rigidbody2D rb;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (CanMove)
        {
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            rb.velocity = movement * moveSpeed;

            bool isMoving = movement.x != 0f || movement.y != 0;
            animator.SetBool("isWalking", isMoving);
            spriteRenderer.flipX = movement.x < 0f;
        }
    }
}
