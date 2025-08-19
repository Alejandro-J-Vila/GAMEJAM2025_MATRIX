using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 8; // Projectile speed
    private float lifetime = 5; // Time until the projectile destroys itself
    private GameObject target; // Reference to the target, aka the player
    private Rigidbody2D rb; // Reference to the rigid body of the projectile

    void Start()
    {
        // Get the rigid body component of the projectile
        rb = GetComponent<Rigidbody2D>();
        // Get target reference
        target = GameObject.FindGameObjectWithTag("Player");
        // Get a direction for the projectile to follow
        Vector2 direction = target.transform.position - transform.position;
        // Move the projectile towards the target
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;
        // Get the angle in which the projectile has to turn to face the target
        float projectileRotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        // Rotate the projectile to face the target
        transform.rotation = Quaternion.Euler(0, 0, projectileRotation);
        // Destroy the projectile after it's lifetime has passed
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If the projectile collides with the player
        if (collision.CompareTag("Player"))
        {
            // Play player damage sound
            SoundManager.sm.PlaySound(collision.gameObject.GetComponent<PlayerController2D>().damageSoundID);
            // Damages him
            GameManager.gm.DamagePlayer();
            // Destroy proyectile
            Destroy(gameObject);
        }
    }
}
