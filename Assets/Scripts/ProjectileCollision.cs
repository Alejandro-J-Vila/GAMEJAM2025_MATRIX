using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // When the projectile collides with an enemy
        if (other.CompareTag("Enemy"))
        {
            // Add progress
            GameManager.gm.AddProgress();
            // Spawn the power up in the enemy position and rotation
            SpawnManager.sm.SpawnPowerUp(other.transform.position, other.transform.rotation);
            // Destroy both
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
