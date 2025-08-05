using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        // When the enemy collides with the player
        if (other.collider.CompareTag("Player"))
        {
            // Damages him
            GameManager.gm.DamagePlayer();
            // Add progress
            GameManager.gm.AddProgress();
            // Die
            Destroy(gameObject);
        }
    }
}
