using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string powerUpType; // Power up type
    public float rotationSpeed = 90f; // Power up rotation speed
    public string powerUpPickUpSoundID; // Power up pick up sound id

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
            // Use the powerup
            GameManager.gm.UsePowerUp(powerUpType);
            // Play the sound of the powerup
            SoundManager.sm.PlaySound(powerUpPickUpSoundID);
            // Destroy the powerup
            Destroy(gameObject);
        }
    }
}
