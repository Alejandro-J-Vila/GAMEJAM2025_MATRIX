using System;
using UnityEngine;

public class CollectiblePickUp : MonoBehaviour
{
    public string collectibleType;
    void OnTriggerEnter2D(Collider2D other)
    {
        // When the player collides with an collectible
        if (other.CompareTag("Player"))
        {
            // Use the power up
            GameManager.gm.UseCollectible(collectibleType);
            // And destroy it
            Destroy(gameObject);
        }
    }
}
