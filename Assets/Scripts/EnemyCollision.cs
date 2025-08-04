using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // When the enemy collides with the player, damages him
        if (other.CompareTag("Player"))
        {
            //TODO
        }
    }
}
