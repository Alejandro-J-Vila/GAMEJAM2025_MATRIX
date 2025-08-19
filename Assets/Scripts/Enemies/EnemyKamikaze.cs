using UnityEngine;

public class EnemyKamikaze : Enemy
{
    public float movementSpeed = 3; // Enemy movement speed
    private GameObject target; // Enemy's target to chase
    private Rigidbody2D rb; // Rigidbody2D component of the enemy

    void Start()
    {
        // Get target reference
        target = GameObject.FindGameObjectWithTag("Player");
        // Get the rigidbody reference
        rb = GetComponent<Rigidbody2D>();
        // Prevent the object from rotating continuosly
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Calculate the movement direction towards the target
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * movementSpeed);
        FaceTarget();
    }

    void FaceTarget()
    {
        // Get the direction of the enemy
        Vector2 targetDirection = (target.transform.position - transform.position).normalized;
        // If the target is in the right side of the screen
        if (targetDirection.x >= 0)
        {
            // If the enemy is not facing right
            if (transform.rotation.y > 0)
            {
                // Flip the enemy to face to the right
                transform.RotateAround(transform.position, Vector3.up, -180);
            }
        }
        else
        {
            // If the target is in the left side of the screen
            // If the enemy is not facing left
            if (transform.rotation.y == 0)
            {
                // Flip the enemy to face to the left
                transform.RotateAround(transform.position, Vector3.up, 180);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // When the enemy collides with the player
        if (other.collider.CompareTag("Player"))
        {
            // Damages the player
            GameManager.gm.DamagePlayer();
            // Play the sound of the enemy attack
            SoundManager.sm.PlaySound(attackSoundID);
            // Destroy enemy
            Destroy(gameObject);
        }
    }
}
