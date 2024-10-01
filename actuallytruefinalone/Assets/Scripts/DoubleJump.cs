using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private int jumpCount;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground check using raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
        Debug.Log("Is Grounded: " + isGrounded); // Log whether grounded
        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, Color.red);

        if (isGrounded)
        {
            jumpCount = 0;
            velocity.y = -0.5f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded || jumpCount < 1)
            {
                Jump();
            }
        }

        controller.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        jumpCount++;
    }
}