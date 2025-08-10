using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 10; // Projectile speed
    private float lifetime = 5; // Time until the projectile destroys itself

    void Start()
    {
        // Destroy the projectile after it's lifetime has passed
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Moves the object forward
        transform.Translate(Vector2.right * Time.deltaTime * speed);
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
            // Destroy the projectile and the enemy
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
