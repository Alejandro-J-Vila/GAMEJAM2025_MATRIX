using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the enemy projectile
    public GameObject projectileSpawn; // Spawn point for enemy projectiles
    public float fireRate = 5f; // Time between enemy shots
    private float nextShot = 0f; // Tracks next time to shoot

    void Start()
    {

    }

    void Update()
    {
        // If the enemy fire cooldown is off
        if (Time.time >= nextShot)
        {
            // Create projectile in the spawn point to fire it
            Instantiate(projectilePrefab, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
            // Update fire cooldown
            nextShot = Time.time + fireRate;
        }
    }
}
