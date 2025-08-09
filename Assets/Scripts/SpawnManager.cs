using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager sm; // Static reference of the spawn manager
    public GameObject enemyKamikaze; // Enemy to spawn
    public GameObject enemyStatic; // Enemy to spawn
    public GameObject powerUp; // Power Up to spawn
    public GameObject staticSpawn; // Spawn point for startic enemies
    public GameObject[] enemySpawnPoints; // List of enemy spawn points in the level
    private float verticalEnemySpawnRange = 5; // Vertical enemy spawn position range
    private float horizontalEnemySpawnRange = 10; // Horizontal enemy spawn position range
    private float enemySpawnStartDelay = 2; // Delay to start spawning enemies
    private float enemySpawnInterval = 2f; // Enemy spawn cooldown
    private int powerUpMaxCount = 5; // Max quantity of powerups in scene
    private int powerUpCount = 0; // Current quantity of power ups in scene
    void Start()
    {
        if (sm != null && sm != this)
        {
            Destroy(gameObject); // Only one instance of spawn manager allowed
        }
        else
        {
            sm = this; // Inicialise the spawn manager instance
        }
        // Continuosly spawn enemies
        InvokeRepeating("SpawnEnemyKamikaze", enemySpawnStartDelay, enemySpawnInterval);
        InvokeRepeating("SpawnEnemyStatic", 10f, 4f);
    }

    void Update()
    {

    }

    void SpawnEnemyKamikaze()
    {
        // Select a random spawn point
        int spawnIndex = Random.Range(0, enemySpawnPoints.Length);
        // Variables for position and rotation of the spawned enemy
        Vector2 spawnPos = new Vector2();
        Quaternion spawnRot = enemySpawnPoints[spawnIndex].transform.rotation;
        // If the spawn point selected is a vertical one
        if (enemySpawnPoints[spawnIndex].CompareTag("VerticalSpawn"))
        {
            // Calculate the enemy position within the horizontal range
            spawnPos = new Vector2(Random.Range(-horizontalEnemySpawnRange, horizontalEnemySpawnRange), enemySpawnPoints[spawnIndex].transform.position.y);
        }
        // If the spawn point is a horizontal one
        else if (enemySpawnPoints[spawnIndex].CompareTag("HorizontalSpawn"))
        {
            // Calculate the enemy position within the vertical range
            spawnPos = new Vector2(enemySpawnPoints[spawnIndex].transform.position.x, Random.Range(-verticalEnemySpawnRange, verticalEnemySpawnRange));
        }
        // Spawn the enemy
        Instantiate(enemyKamikaze, spawnPos, spawnRot);
    }

    void SpawnEnemyStatic()
    {
        // Select a random spawn point
        int spawnIndex = Random.Range(0, enemySpawnPoints.Length);
        // Variables for position and rotation of the spawned enemy
        Vector2 spawnPos = new Vector2(Random.Range(-8, 8), Random.Range(-3, 3));
        Quaternion spawnRot = staticSpawn.transform.rotation;
        // Spawn the enemy
        Instantiate(enemyStatic, spawnPos, spawnRot);
    }

    public void SpawnPowerUp(Vector3 position, Quaternion rotation)
    {
        if (powerUpCount < powerUpMaxCount)
        {
            // Calculate a random number for spawning power up
            int rn = Random.Range(0, 5);
            // 1 in 5 chances to spawn a power up
            if (rn == 3)
            {
                // Spawn a power up in a given position and rotation
                Instantiate(powerUp, position, rotation);
                powerUpCount++;
            }
        }
    }

    public void ConsumePowerUp()
    {
        if (powerUpCount > 0)
        {
            powerUpCount--;
        }
    }
}
