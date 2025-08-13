using UnityEngine;

public class EnemyStatic : Enemy
{
    public GameObject projectile; // Reference to the enemy projectile
    public GameObject projectileSpawn; // Spawn point for enemy projectiles
    public int fireRate = 3; // Time between enemy shots
    private float fireTimer = 2; // Tracks next time to shoot

    void Update()
    {
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

    void Fire()
    {
        // Create projectile in the spawn point to fire it
        Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        // Play attack sound
        //SoundManager.sm.PlaySound(attackSoundID);
    }
}
