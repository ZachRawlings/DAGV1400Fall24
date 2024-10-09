using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    public float repellingForce = 10f; // Public variable to set the force in the Inspector

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug log to check collisions
        Debug.Log("Collided with: " + collision.gameObject.name);

        // Check if the collided object has the tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Calculate the direction from the enemy to the character
            Vector2 direction = (transform.position - collision.transform.position).normalized;

            // Apply the repelling force
            rb.velocity = Vector2.zero; // Reset velocity to avoid compounding forces
            rb.AddForce(direction * repellingForce, ForceMode2D.Impulse);
            Debug.Log("Repelling force applied: " + direction * repellingForce);
        }
    }
}
