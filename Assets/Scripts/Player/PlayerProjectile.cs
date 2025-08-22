using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 10; // Projectile speed
    private float lifetime = 5; // Time until the projectile destroys itself
    private Vector2 movementDirection; // Projectile direction
    private Rigidbody2D rb; // Reference to the rigid body of the projectile
    public GameObject particlePrefab; //Particle prefab
    private ParticleSystem particle; // Particle system

    void Start()
    {

        // Get the rigid body component to apply movement
        rb = GetComponent<Rigidbody2D>();
        // Destroy the projectile after it's lifetime has passed
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate()
    {
        // Move the projectile
        rb.linearVelocity = movementDirection * speed;
    }

    public void SetDirection(Vector2 direction)
    {
        // Sets the movement direction
        movementDirection = direction;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // When the projectile collides with an enemy
        if (other.CompareTag("Enemy"))
        {
            // Add progress
            GameManager.gm.AddProgress();
            // Spawn a power up in the enemy position
            SpawnManager.sm.SpawnPowerUp(other.transform.position, Quaternion.identity);
            // Play enemy death sound
            SoundManager.sm.PlaySound(other.gameObject.GetComponent<Enemy>().deathSoundID);
            // Play the particle
            GameObject instantiatedParticleSystem = Instantiate(particlePrefab,other.gameObject.transform.position,other.gameObject.transform.rotation);
            particle=instantiatedParticleSystem.GetComponent<ParticleSystem>();
            particle.Play();
            // Destroy the projectile and the enemy
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
