using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string powerUpType; // Power up type
    public float rotationSpeed = 90f; // Power up rotation speed

    void Update()
    {
        // Rotate the power up arround Y axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // When the player collides with a power up
        if (other.CompareTag("Player"))
        {
            // Use it
            GameManager.gm.UsePowerUp(powerUpType);
            // Destroy it
            Destroy(gameObject);
        }
    }
}
