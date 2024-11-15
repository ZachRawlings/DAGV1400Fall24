using UnityEngine;
using System.Collections; // Required for IEnumerator

[RequireComponent(typeof(ParticleSystem), typeof(Collider2D))]
public class TriggerParticleEffect : MonoBehaviour
{
    private ParticleSystem myParticleSystem; // Renamed variable to avoid conflict
    public int minParticleAmount = 5; // Minimum particles per loop
    public int maxParticleAmount = 15; // Maximum particles per loop

    public float emissionInterval = 0.5f; // Time between each emission
    public int emissionCount = 3; // Number of emissions

    private void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CapsuleCollider2D>()) // Check if the player triggered the event
        {
            StartCoroutine(EmitParticlesOverTime()); // Start the coroutine
        }
    }

    private IEnumerator EmitParticlesOverTime()
    {
        for (int i = 0; i < emissionCount; i++) // Loop for a set number of emissions
        {
            int particleAmount = Random.Range(minParticleAmount, maxParticleAmount + 1); // Generate a random amount
            myParticleSystem.Emit(particleAmount); // Emit the generated amount of particles
            yield return new WaitForSeconds(emissionInterval); // Wait for the specified interval
        }
    }
}
