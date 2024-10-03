using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f; // Height of the first jump
    public float secondJumpForce = 8f; // Height of the second jump
    public float fallMultiplier = 2.5f; // Fall speed multiplier when holding jump
    public LayerMask groundLayer; // Layer to define what is ground
    public float GroundCheck = 0.65f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount; // Tracks how many jumps have been performed

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0; // Initialize jump count
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Flip the character based on movement direction
        if (horizontalInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontalInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
    }

    private void Jump()
    {
        // Check if the character is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        // Reset jump count when grounded
        if (isGrounded && rb.velocity.y <= 0)
        {
            jumpCount = 0; // Reset jump count when touching the ground
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                // First jump
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount = 1; // Allow double jump
            }
            else if (jumpCount < 2)
            {
                // Double jump
                rb.velocity = new Vector2(rb.velocity.x, secondJumpForce);
                jumpCount++; // Increment jump count after second jump
            }
        }

        // Apply fall multiplier if the jump button is held
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        // Draw a ray for ground detection
        Gizmos.color = Color.red;
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.down * GroundCheck);
    }
}
