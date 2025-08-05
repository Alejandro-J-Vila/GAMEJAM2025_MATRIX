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
            // Destroy both
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            //TODO
        }
    }
}
