using UnityEngine;

public class EnemyStatic : Enemy
{
    public GameObject projectile; // Reference to the enemy projectile
    public GameObject projectileSpawn; // Spawn point for enemy projectiles
    public int fireRate = 3; // Time between enemy shots
    private GameObject target; // Reference to the target, aka the player
    private float fireTimer = 2; // Tracks next time to shoot

    void Start()
    {
        // Get target reference
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        FaceTarget();
        // Increase fire timer in seconds with passing time
        fireTimer += Time.deltaTime;
        // If the fire cooldown is off
        if (fireTimer >= fireRate)
        {
            // Reset the fire timer
            fireTimer = 0;
            // Fire a projectile
            Fire();
        }
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

    void Fire()
    {
        // Create projectile in the spawn point to fire it
        Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        // Play attack sound
        //SoundManager.sm.PlaySound(attackSoundID);
    }
}
